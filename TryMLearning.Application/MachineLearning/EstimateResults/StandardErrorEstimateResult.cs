using TryMLearning.Application.Interface.MachineLearning.EstimateResults;
using TryMLearning.Model.MachineLearning.Reports;

namespace TryMLearning.Application.MachineLearning.EstimateResults
{
    public class StandardErrorEstimateResult : IEstimateResult
    {
        public double StandardError { get; }

        public StandardErrorEstimateResult(double standardError)
        {
            StandardError = standardError;
        }

        public void Render(ClassificationReport classificationReport)
        {
            classificationReport.StandardError = StandardError;
        }
    }
}