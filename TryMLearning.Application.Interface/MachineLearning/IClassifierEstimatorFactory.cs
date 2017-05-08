using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierEstimatorFactory
    {
        IClassifierEstimator GetClassifierEstimator(AlgorithmEstimation algorithmEstimation);
    }
}