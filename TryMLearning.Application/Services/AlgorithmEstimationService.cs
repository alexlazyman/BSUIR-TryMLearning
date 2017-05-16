using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Contexts;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmEstimationService : IAlgorithmEstimationService
    {
        private readonly ITransactionScope _transactionScope;
        private readonly IUserContext _userContext;

        private readonly IAlgorithmEstimationDao _algorithmEstimationDao;
        private readonly IAlgorithmParameterValueDao _algorithmParameterValueDao;

        private readonly ISampleService<ClassificationSample> _classificationSampleService;
        private readonly IClassificationResultService _classificationResultService;
        private readonly IClassifierFactory _classifierFactory;
        private readonly IClassifierEstimatorFactory _classifierEstimatorFactory;
        private readonly IClassifierEstimateFactory _classifierEstimateFactory;

        private readonly IValidator<AlgorithmEstimation> _algorithmEstimationValidator;

        public AlgorithmEstimationService(
            ITransactionScope transactionScope,
            IUserContext userContext,
            IAlgorithmEstimationDao algorithmEstimationDao,
            IAlgorithmParameterValueDao algorithmParameterValueDao,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassificationResultService classificationResultService,
            IClassifierFactory classifierFactory,
            IClassifierEstimatorFactory classifierEstimatorFactory,
            IClassifierEstimateFactory classifierEstimateFactory,
            IValidator<AlgorithmEstimation> algorithmEstimationValidator)
        {
            _transactionScope = transactionScope;
            _userContext = userContext;
            _algorithmEstimationDao = algorithmEstimationDao;
            _algorithmParameterValueDao = algorithmParameterValueDao;
            _classificationSampleService = classificationSampleService;
            _classificationResultService = classificationResultService;
            _classifierFactory = classifierFactory;
            _classifierEstimatorFactory = classifierEstimatorFactory;
            _classifierEstimateFactory = classifierEstimateFactory;
            _algorithmEstimationValidator = algorithmEstimationValidator;
        }

        public async Task<List<AlgorithmEstimation>> GetAllAlgorithmEstimationsAsync()
        {
            var id = _userContext.GetCurrentUserId();
            if (id == null)
            {
                throw new UnauthorizedAccessException();
            }

            return await _algorithmEstimationDao.GetAllAlgorithmEstimationsAsync(id.Value);
        }

        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            return await _algorithmEstimationDao.GetAlgorithmEstimationAsync(algorithmEstimationId);
        }

        public async Task<AlgorithmEstimation> RunEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            var id = _userContext.GetCurrentUserId();
            if (id == null)
            {
                throw new UnauthorizedAccessException();
            }

            algorithmEstimation.User = new User { UserId = id.Value };

            var validationResult = await _algorithmEstimationValidator.ValidateAsync(algorithmEstimation);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            AlgorithmEstimation addedAlgorithmEstimation = null;

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    addedAlgorithmEstimation = await _algorithmEstimationDao.InsertAlgorithmEstimationAsync(algorithmEstimation);
                    foreach (var parameterValue in algorithmEstimation.ParameterValues)
                    {
                        parameterValue.AlgorithmEstimationId = addedAlgorithmEstimation.AlgorithmEstimationId;
                        var addedAlgorithmParameterValue =  await _algorithmParameterValueDao.InsertAlgorithmParameterValueAsync(parameterValue);

                        addedAlgorithmEstimation.ParameterValues.Add(addedAlgorithmParameterValue);
                    }

                    await _algorithmEstimationDao.QueueAlgorithmEstimationAsync(addedAlgorithmEstimation);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return addedAlgorithmEstimation;
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

            var classifier = _classifierFactory.GetClassifier(algorithmEstimation.Algorithm);
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

        public async Task<List<EstimateResponse>> GetClassifierEstimationResultAsync(int algorithmEstimationId, List<EstimateRequest> estimateRequests)
        {
            var algorithmEstimation = await _algorithmEstimationDao.GetAlgorithmEstimationAsync(algorithmEstimationId);
            if (!IsClassifierExtimation(algorithmEstimation))
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not classifier estimation");
            }

            if (algorithmEstimation.Status != AlgorithmEstimationStatus.Completed)
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not completed");
            }

            var classifierEstimator = _classifierEstimatorFactory.GetClassifierEstimator(algorithmEstimation);

            var estimates = estimateRequests.Select(_classifierEstimateFactory.GetEstimate).ToList();
            var classificationResults = await _classificationResultService.GetClassificationResultsAsync(algorithmEstimation.AlgorithmEstimationId);

            var estimateResponses = classifierEstimator.Estimate(classificationResults, estimates);

            return estimateResponses;
        }

        private bool IsClassifierExtimation(AlgorithmEstimation algorithmEstimation)
        {
            if (algorithmEstimation.Algorithm.Type != AlgorithmType.Classifier)
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