using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Contexts;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class EstimationService : IEstimationService
    {
        private readonly ITransactionScope _transactionScope;
        private readonly IUserContext _userContext;

        private readonly IEstimationDao _estimationDao;
        private readonly IAlgorithmParameterValueDao _algorithmParameterValueDao;

        private readonly ISampleService<ClassificationSample> _classificationSampleService;
        private readonly IClassificationResultService _classificationResultService;
        private readonly IClassifierFactory _classifierFactory;
        private readonly IClassifierEstimator _classifierEstimator;
        private readonly IClassifierEstimateFactory _classifierEstimateFactory;

        private readonly IValidator<Estimation> _estimationValidator;

        public EstimationService(
            ITransactionScope transactionScope,
            IUserContext userContext,
            IEstimationDao estimationDao,
            IAlgorithmParameterValueDao algorithmParameterValueDao,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassificationResultService classificationResultService,
            IClassifierFactory classifierFactory,
            IClassifierEstimator classifierEstimator,
            IClassifierEstimateFactory classifierEstimateFactory,
            IValidator<Estimation> estimationValidator)
        {
            _transactionScope = transactionScope;
            _userContext = userContext;
            _estimationDao = estimationDao;
            _algorithmParameterValueDao = algorithmParameterValueDao;
            _classificationSampleService = classificationSampleService;
            _classificationResultService = classificationResultService;
            _classifierFactory = classifierFactory;
            _classifierEstimator = classifierEstimator;
            _classifierEstimateFactory = classifierEstimateFactory;
            _estimationValidator = estimationValidator;
        }

        public async Task<List<Estimation>> GetAllEstimationsAsync()
        {
            var id = _userContext.GetCurrentUserId();
            if (id == null)
            {
                throw new UnauthorizedAccessException();
            }

            return await _estimationDao.GetAllEstimationsAsync(id.Value);
        }

        public async Task<Estimation> GetEstimationAsync(int estimationId)
        {
            return await _estimationDao.GetEstimationAsync(estimationId);
        }

        public async Task DeleteEstimationAsync(int estimationId)
        {
            var id = _userContext.GetCurrentUserId();
            if (id == null)
            {
                throw new UnauthorizedAccessException();
            }

            var estimation = await _estimationDao.GetEstimationAsync(estimationId);
            if (estimation.User.UserId != id)
            {
                throw new UnauthorizedAccessException();
            }

            await _estimationDao.DeleteEstimationAsync(estimation);
        }

        public async Task<Estimation> RunEstimationAsync(Estimation estimation)
        {
            var id = _userContext.GetCurrentUserId();
            if (id == null)
            {
                throw new UnauthorizedAccessException();
            }

            estimation.User = new User { UserId = id.Value };

            var validationResult = await _estimationValidator.ValidateAsync(estimation);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            Estimation addedEstimation = null;

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    addedEstimation = await _estimationDao.InsertEstimationAsync(estimation);
                    foreach (var parameterValue in estimation.ParameterValues)
                    {
                        parameterValue.EstimationId = addedEstimation.EstimationId;
                        var addedAlgorithmParameterValue =  await _algorithmParameterValueDao.InsertAlgorithmParameterValueAsync(parameterValue);

                        addedEstimation.ParameterValues.Add(addedAlgorithmParameterValue);
                    }

                    await _estimationDao.QueueEstimationAsync(addedEstimation);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return addedEstimation;
        }

        public async Task ExecuteClassifierEstimationAsync(int estimationId)
        {
            var estimation = await _estimationDao.GetEstimationAsync(estimationId);
            if (!IsClassifierExtimation(estimation))
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not classifier estimation");
            }

            estimation.Status = EstimationStatus.InProgress;
            await _estimationDao.UpdateEstimationAsync(estimation);

            var completedEstimation = await _estimationDao.GetCompletedEstimationAsync(
                estimation.Algorithm.AlgorithmId,
                estimation.DataSet.DataSetId);

            List<ClassificationResult> classificationResults = null;

            if (completedEstimation != null)
            {
                classificationResults = await _classificationResultService.GetClassificationResultsAsync(completedEstimation.EstimationId);
                classificationResults.ForEach(r => r.EstimationId = estimationId);
            }
            else
            {
                var classifier = _classifierFactory.GetClassifier(estimation.Algorithm);

                var algorithmParameterValuePairs = estimation.Algorithm.Parameters
                    .Join(
                        estimation.ParameterValues,
                        p => p.AlgorithmParameterId,
                        v => v.AlgorithmParameterId,
                        (p, v) => new AlgorithmParameterValuePair
                        {
                            Parameter = p,
                            Value = v
                        })
                    .ToList();

                classifier.Init(algorithmParameterValuePairs);

                var samples = await _classificationSampleService.GetAllSamplesAsync(estimation.DataSet.DataSetId);

                classificationResults = _classifierEstimator.Classify(samples, classifier);
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    await _classificationResultService.AddClassificationResultsAsync(estimationId, classificationResults);

                    estimation.Status = EstimationStatus.Completed;
                    await _estimationDao.UpdateEstimationAsync(estimation);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

        }

        public async Task<List<EstimateResult>> GetClassifierEstimationResultAsync(int estimationId, List<EstimateRequest> estimateRequests)
        {
            var estimation = await _estimationDao.GetEstimationAsync(estimationId);
            if (!IsClassifierExtimation(estimation))
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not classifier estimation");
            }

            if (estimation.Status != EstimationStatus.Completed)
            {
                throw new UnauthorizedAccessException("Algorithm estimation is not completed");
            }

            var estimates = estimateRequests.Select(_classifierEstimateFactory.GetEstimate).ToList();
            var classificationResults = await _classificationResultService.GetClassificationResultsAsync(estimation.EstimationId);

            var estimateResponses = _classifierEstimator.Estimate(classificationResults, estimates);

            return estimateResponses;
        }

        private bool IsClassifierExtimation(Estimation estimation)
        {
            if (estimation.Algorithm.Type != AlgorithmType.Classifier)
            {
                return false;
            }

            if (estimation.DataSet.Type != DataSetType.Classification)
            {
                return false;
            }

            return true;
        }
    }
}