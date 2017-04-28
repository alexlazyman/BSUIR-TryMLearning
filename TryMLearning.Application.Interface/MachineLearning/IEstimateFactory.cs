using TryMLearning.Application.Interface.MachineLearning.Estimates;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IEstimateFactory
    {
        IEstimate GetEstimate(string estimateAlias);
    }
}