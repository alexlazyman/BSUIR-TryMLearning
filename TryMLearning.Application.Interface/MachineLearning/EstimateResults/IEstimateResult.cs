using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Reports;

namespace TryMLearning.Application.Interface.MachineLearning.EstimateResults
{
    public interface IEstimateResult
    {
        void Render(ClassificationReport classificationReport);
    }
}