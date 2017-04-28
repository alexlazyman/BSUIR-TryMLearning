using TryMLearning.Application.Interface.MachineLearning.EstimateResults;

namespace TryMLearning.Application.Interface.MachineLearning.Estimates
{
    public interface IEstimate
    {
        int Count { get; }

        IEstimateResult Estimate(bool[] results, bool accumulate = false);

        IEstimateResult Average { get; }
    }
}