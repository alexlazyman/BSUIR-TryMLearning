using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalseNegativeError
{
    public class FalseNegativeErrorResult : IClassifierEstimateResult
    {
        public double FalseNegativeError { get; }

        public FalseNegativeErrorResult(double falseNegativeError)
        {
            FalseNegativeError = falseNegativeError;
        }

        public void Render(ClassifierEstimationResult classifierEstimationResult)
        {
            classifierEstimationResult.FalseNegativeError = FalseNegativeError;
        }
    }
}