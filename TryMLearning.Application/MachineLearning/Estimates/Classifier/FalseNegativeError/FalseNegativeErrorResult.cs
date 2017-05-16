using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalseNegativeError
{
    public class FalseNegativeErrorResult
    {
        public double FalseNegativeError { get; }

        public FalseNegativeErrorResult(double falseNegativeError)
        {
            FalseNegativeError = falseNegativeError;
        }
    }
}