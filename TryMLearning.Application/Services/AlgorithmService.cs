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
        private readonly IDataSetService _dataSetService;
        private readonly ISampleService<ClassificationSample> _classificationSampleService;

        private readonly IClassifierFactory _classifierFactory;
        private readonly IClassifierEstimator _classifierEstimator;

        private readonly IValidator<Algorithm> _algorithmValidator;
        private readonly IValidator<AlgorithmEstimate> _algorithmEstimateValidator;

        public AlgorithmService(
            ITransactionScope transactionScope,
            IAlgorithmDao algorithmDao,
            IAlgorithmParameterDao algorithmParameterDao,
            IAlgorithmEstimateService algorithmEstimateService,
            IDataSetService dataSetService,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassifierFactory classifierFactory,
            IClassifierEstimator classifierEstimator,
            IValidator<Algorithm> algorithmValidator,
            IValidator<AlgorithmEstimate> algorithmEstimateValidator)
        {
            _transactionScope = transactionScope;
            _algorithmDao = algorithmDao;
            _classificationSampleService = classificationSampleService;
            _algorithmParameterDao = algorithmParameterDao;
            _algorithmEstimateService = algorithmEstimateService;
            _dataSetService = dataSetService;
            _classifierFactory = classifierFactory;
            _classifierEstimator = classifierEstimator;
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

        public async Task<AlgorithmEstimate> RunAlgorithmAsync(int algorithmId, int dataSetId, List<AlgorithmParameterValue> parameterValues)
        {
            var algorithEstimate = new AlgorithmEstimate()
            {
                AlgorithmId = algorithmId,
                DataSetId = dataSetId,
                ParameterValues = parameterValues
            };

            var validationResult = await _algorithmEstimateValidator.ValidateAsync(algorithEstimate);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithEstimate = await _algorithmEstimateService.AddAlgorithmEstimateAsync(algorithEstimate);
                    await _algorithmDao.AddAlgorithmToRunQueue(algorithEstimate);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithEstimate;
        }

        public async Task EstimateClassificationAlgorithmAsync(int algorithmEstimateId)
        {
            var algorithmEstimate = await _algorithmEstimateService.GetAlgorithmEstimateAsync(algorithmEstimateId);

            var algorithm = await GetAlgorithmAsync(algorithmEstimate.AlgorithmId);
            if (!algorithm.IsClassificationAlgorithm)
            {
                return;
            }

            var dataSet = await _dataSetService.GetDataSetAsync(algorithmEstimate.DataSetId);
            if (dataSet.Type != DataSetType.Classification)
            {
                return;
            }

            var sampleCount = await _classificationSampleService.GetSampleCountAsync(dataSet.DataSetId);
            var samples = await _classificationSampleService.GetSamplesAsync(dataSet.DataSetId, 0, sampleCount);

            var classifier = _classifierFactory.GetClassifier(algorithm.Alias);

            var classificationReport = _classifierEstimator.Estimate(
                classifier,
                samples.ToArray(),
                algorithmEstimate.Estimates.ToArray());

            // TODO: Save classificationReport.
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