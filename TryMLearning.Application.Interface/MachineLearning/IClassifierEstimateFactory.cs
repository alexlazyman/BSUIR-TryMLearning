using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierEstimateFactory
    {
        IClassifierEstimate GetEstimate(EstimateRequest estimateRequest);
    }
}