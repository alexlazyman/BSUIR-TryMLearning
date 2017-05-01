using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Model.Validation;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly ITransactionScope _transactionScope;

        private readonly IAlgorithmDao _algorithmDao;
        private readonly IAlgorithmParameterDao _algorithmParameterDao;

        private readonly IAlgorithmEstimateService _algorithmEstimateService;
        private readonly ISampleService<ClassificationSample> _classificationSampleService;
        private readonly IClassificationResultService _classificationResultService;

        private readonly IClassifierFactory _classifierFactory;
        private readonly IClassifierServiceFactory _classifierServiceFactory;

        private readonly IValidator<Algorithm> _algorithmValidator;
        private readonly IValidator<AlgorithmEstimate> _algorithmEstimateValidator;

        public AlgorithmService(
            ITransactionScope transactionScope,
            IAlgorithmDao algorithmDao,
            IAlgorithmParameterDao algorithmParameterDao,
            IAlgorithmEstimateService algorithmEstimateService,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassificationResultService classificationResultService,
            IClassifierFactory classifierFactory,
            IClassifierServiceFactory classifierServiceFactory,
            IValidator<Algorithm> algorithmValidator,
            IValidator<AlgorithmEstimate> algorithmEstimateValidator)
        {
            _transactionScope = transactionScope;
            _algorithmDao = algorithmDao;
            _classificationSampleService = classificationSampleService;
            _classificationResultService = classificationResultService;
            _algorithmParameterDao = algorithmParameterDao;
            _algorithmEstimateService = algorithmEstimateService;
            _classifierFactory = classifierFactory;
            _classifierServiceFactory = classifierServiceFactory;
            _algorithmValidator = algorithmValidator;
            _algorithmEstimateValidator = algorithmEstimateValidator;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }

            Algorithm addedAlgorithm = null;

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithm.AlgorithmId = 0;
                    addedAlgorithm = await _algorithmDao.AddAlgorithmAsync(algorithm);

                    addedAlgorithm.Parameters = new List<AlgorithmParameter>();
                    foreach (var algParam in algorithm.Parameters)
                    {
                        algParam.AlgorithmParameterId = 0;
                        algParam.AlgorithmId = addedAlgorithm.AlgorithmId;

                        var addedAlgParam = await _algorithmParameterDao.AddAlgorithmParameterAsync(algParam);

                        addedAlgorithm.Parameters.Add(addedAlgParam);
                    }

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return addedAlgorithm;
        }

        public async Task<List<Algorithm>> GetAllAlgorithmsAsync()
        {
            var algorithms = await _algorithmDao.GetAllAlgorithmsAsync();

            return algorithms;
        }

        public async Task<Algorithm> GetAlgorithmAsync(int algorithmId)
        {
            var algorithm = await _algorithmDao.GetAlgorithmAsync(algorithmId);

            return algorithm;
        }

        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }
            
            var existingAlgorithm = await _algorithmDao.GetAlgorithmAsync(algorithm.AlgorithmId);
            if (existingAlgorithm == null)
            {
                throw new UnauthorizedAccessException("Algorithm does not exist");
            }

            foreach (var algParam in algorithm.Parameters)
            {
                algParam.AlgorithmId = algorithm.AlgorithmId;
                if (algParam.AlgorithmParameterId != 0 &&
                    existingAlgorithm.Parameters.All(p => p.AlgorithmParameterId != algParam.AlgorithmParameterId))
                {
                    algParam.AlgorithmParameterId = 0;
                }
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    await _algorithmDao.UpdateAlgorithmAsync(algorithm);
                    await UpdateAlgorithmParametersAsync(existingAlgorithm.Parameters, algorithm.Parameters);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithm;
        }

        public async Task DeleteAlgorithmAsync(int algorithmId)
        {
            var algorithm = new Algorithm() { AlgorithmId = algorithmId };

            await _algorithmDao.DeleteAlgorithmAsync(algorithm);
        }

        public async Task<AlgorithmEstimate> RunAlgorithmAsync(AlgorithmEstimate algorithmEstimate)
        {
            var validationResult = await _algorithmEstimateValidator.ValidateAsync(algorithmEstimate);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithmEstimate = await _algorithmEstimateService.AddAlgorithmEstimateAsync(algorithmEstimate);
                    await _algorithmDao.AddAlgorithmToRunQueue(algorithmEstimate);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithmEstimate;
        }

        // TODO: Add update of status.
        public async Task EstimateClassificationAlgorithmAsync(int algorithmEstimateId)
        {
            var algorithmEstimate = await _algorithmEstimateService.GetAlgorithmEstimateAsync(algorithmEstimateId);

            if (!algorithmEstimate.Algorithm.IsClassificationAlgorithm)
            {
                // TODO: Throw error.
                return;
            }

            if (algorithmEstimate.DataSet.Type != DataSetType.Classification)
            {
                // TODO: Throw error.
                return;
            }

            var classifier = _classifierFactory.GetClassifier(algorithmEstimate.Algorithm.Alias);
            var classifierService = _classifierServiceFactory.GetClassifierService(algorithmEstimate);

            var sampleCount = await _classificationSampleService.GetSampleCountAsync(algorithmEstimate.DataSet.DataSetId);
            var samples = await _classificationSampleService.GetSamplesAsync(algorithmEstimate.DataSet.DataSetId, 0, sampleCount);

            var classificationResults = classifierService.Classify(samples, classifier).ToList();

            await _classificationResultService.AddClassificationResultsAsync(algorithmEstimateId, classificationResults);
        }

        private async Task UpdateAlgorithmParametersAsync(List<AlgorithmParameter> existingAlgParams, List<AlgorithmParameter> updatedAlgParams)
        {
            existingAlgParams = existingAlgParams ?? new List<AlgorithmParameter>();
            updatedAlgParams = updatedAlgParams ?? new List<AlgorithmParameter>();

            for (var i = 0; i < existingAlgParams.Count; i++)
            {
                if (updatedAlgParams.All(p => p.AlgorithmParameterId != existingAlgParams[i].AlgorithmParameterId))
                {
                    await _algorithmParameterDao.DeleteAlgorithmParameterAsync(existingAlgParams[i]);
                }
            }

            for (var i = 0; i < updatedAlgParams.Count; i++)
            {
                if (updatedAlgParams[i].AlgorithmParameterId == 0)
                {
                    updatedAlgParams[i] = await _algorithmParameterDao.AddAlgorithmParameterAsync(updatedAlgParams[i]);
                }
                else
                {
                    updatedAlgParams[i] = await _algorithmParameterDao.UpdateAlgorithmParameterAsync(updatedAlgParams[i]);
                }
            }
        }
    }
}