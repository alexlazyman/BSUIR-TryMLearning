using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalsePositiveError
{
    public class FalsePositiveErrorResult : IClassifierEstimateResult
    {
        public double FalsePositiveError { get; }

        public FalsePositiveErrorResult(double falsePositiveError)
        {
            FalsePositiveError = falsePositiveError;
        }

        public void Render(ClassifierEstimationResult classifierEstimationResult)
        {
            classifierEstimationResult.FalsePositiveError = FalsePositiveError;
        }
    }
}