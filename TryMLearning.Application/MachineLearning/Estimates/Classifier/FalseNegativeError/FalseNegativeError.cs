using System.Collections.Generic;
using System.Linq;
using TryMLearning.Application.Interface.MachineLearning.Contexts;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalseNegativeError
{
    public class FalseNegativeError : BaseClassifierEstimate<FalseNegativeErrorResult>
    {
        private readonly FNErrorEstimateConfig _config;

        private readonly IClassificationContext _classificationContext;

        public FalseNegativeError(
            FNErrorEstimateConfig config,
            IClassificationContext classificationContext)
        {
            _config = config;
            _classificationContext = classificationContext;
        }

        protected override FalseNegativeErrorResult GetEstimateResult(List<ClassificationResult> classificationResults)
        {
            var falseNegativeError = _classificationContext.GetFalseNegativeError(classificationResults, _config.PrimaryClass);

            return new FalseNegativeErrorResult(falseNegativeError);
        }

        protected override FalseNegativeErrorResult GetAverageResult(List<FalseNegativeErrorResult> estimateResults)
        {
            var falseNegativeError = estimateResults.Sum(r => r.FalseNegativeError) / estimateResults.Count;

            return new FalseNegativeErrorResult(falseNegativeError);
        }
    }
}