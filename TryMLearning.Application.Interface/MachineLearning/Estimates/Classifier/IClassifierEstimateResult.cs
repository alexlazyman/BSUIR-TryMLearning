using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier
{
    public interface IClassifierEstimateResult
    {
        void Render(ClassifierEstimationResult result);
    }
}