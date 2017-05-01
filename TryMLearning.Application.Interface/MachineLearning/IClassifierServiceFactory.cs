using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierServiceFactory
    {
        IClassifierService GetClassifierService(AlgorithmEstimate algorithmEstimate);
    }
}