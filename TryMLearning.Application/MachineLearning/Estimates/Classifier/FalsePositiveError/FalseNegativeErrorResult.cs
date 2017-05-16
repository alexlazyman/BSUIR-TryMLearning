using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalsePositiveError
{
    public class FalsePositiveErrorResult
    {
        public double FalsePositiveError { get; }

        public FalsePositiveErrorResult(double falsePositiveError)
        {
            FalsePositiveError = falsePositiveError;
        }
    }
}