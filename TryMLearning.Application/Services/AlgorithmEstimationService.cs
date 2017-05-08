using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmEstimationService : IAlgorithmEstimationService
    {
        private readonly ITransactionScope _transactionScope;

        private readonly IAlgorithmEstimationDao _algorithmEstimationDao;

        private readonly ISampleService<ClassificationSample> _classificationSampleService;
        private readonly IClassificationResultService _classificationResultService;
        private readonly IClassifierFactory _classifierFactory;
        private readonly IClassifierEstimatorFactory _classifierEstimatorFactory;
        private readonly IClassifierEstimateFactory _classifierEstimateFactory;

        private readonly IValidator<AlgorithmEstimation> _algorithmEstimationValidator;

        public AlgorithmEstimationService(
            ITransactionScope transactionScope,
            IAlgorithmEstimationDao algorithmEstimationDao,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassificationResultService classificationResultService,
            IClassifierFactory classifierFactory,
            IClassifierEstimatorFactory classifierEstimatorFactory,
            IClassifierEstimateFactory classifierEstimateFactory,
            IValidator<AlgorithmEstimation> algorithmEstimationValidator)
        {
            _transactionScope = transactionScope;
            _algorithmEstimationDao = algorithmEstimationDao;
            _classificationSampleService = classificationSampleService;
            _classificationResultService = classificationResultService;
            _classifierFactory = classifierFactory;
            _classifierEstimatorFactory = classifierEstimatorFactory;
            _classifierEstimateFactory = classifierEstimateFactory;
            _algorithmEstimationValidator = algorithmEstimationValidator;
        }

        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            return await _algorithmEstimationDao.GetAlgorithmEstimationAsync(algorithmEstimationId);
        }

        public async Task<AlgorithmEstimation> AddAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            return await _algorithmEstimationDao.InsertAlgorithmEstimationAsync(algorithmEstimation);
        }

        public async Task<AlgorithmEstimation> RunEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            var validationResult = await _algorithmEstimationValidator.ValidateAsync(algorithmEstimation);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithmEstimation = await _algorithmEstimationDao.InsertAlgorithmEstimationAsync(algorithmEstimation);
                    await _algorithmEstimationDao.QueueAlgorithmEstimationAsync(algorithmEstimation);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithmEstimation;
        }

        public async Task ExecuteClassifierEstimationAsync(int algorithmEstimationId)
        {
            var algorithmEstimation = await _algorithmEstimationDao.GetAlgorithmEstimationAsync(algorithmEstimationId);
            if (!IsClassifierExtimation(algorithmEstimation))
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not classifier estimation");
            }

            algorithmEstimation.Status = AlgorithmEstimationStatus.InProgress;
            await _algorithmEstimationDao.UpdateAlgorithmEstimationAsync(algorithmEstimation);

            var classifier = _classifierFactory.GetClassifier(algorithmEstimation.Algorithm.Alias);
            var classifierEstimator = _classifierEstimatorFactory.GetClassifierEstimator(algorithmEstimation);

            var samples = await _classificationSampleService.GetAllSamplesAsync(algorithmEstimation.DataSet.DataSetId);

            var classificationResults = classifierEstimator.Classify(samples, classifier);

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    await _classificationResultService.AddClassificationResultsAsync(algorithmEstimationId, classificationResults);

                    algorithmEstimation.Status = AlgorithmEstimationStatus.Completed;
                    await _algorithmEstimationDao.UpdateAlgorithmEstimationAsync(algorithmEstimation);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

        }

        public async Task<ClassifierEstimationResult> GetClassifierEstimationResultAsync(ClassifierEstimationResultRequest request)
        {
            var algorithmEstimation = await _algorithmEstimationDao.GetAlgorithmEstimationAsync(request.AlgorithmEstimationId);
            if (!IsClassifierExtimation(algorithmEstimation))
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not classifier estimation");
            }

            if (algorithmEstimation.Status != AlgorithmEstimationStatus.Completed)
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not completed");
            }

            var classifierEstimator = _classifierEstimatorFactory.GetClassifierEstimator(algorithmEstimation);

            var estimates = request.Estimates.Select(estimateAlias => _classifierEstimateFactory.GetEstimate(estimateAlias, request)).ToList();
            var classificationResults = await _classificationResultService.GetClassificationResultsAsync(algorithmEstimation.AlgorithmEstimationId);

            var estimateResults = classifierEstimator.Estimate(classificationResults, estimates);

            var result = new ClassifierEstimationResult();

            estimateResults.ForEach(er => er.Render(result));

            return result;
        }

        private bool IsClassifierExtimation(AlgorithmEstimation algorithmEstimation)
        {
            if (!algorithmEstimation.Algorithm.IsClassificationAlgorithm)
            {
                return false;
            }

            if (algorithmEstimation.DataSet.Type != DataSetType.Classification)
            {
                return false;
            }

            return true;
        }
    }
}