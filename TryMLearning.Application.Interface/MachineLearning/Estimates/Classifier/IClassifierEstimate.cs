using System.Collections.Generic;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier
{
    public interface IClassifierEstimate
    {
        int Count { get; }

        IClassifierEstimateResult Estimate(List<ClassificationResult> classificationResults, bool accumulate = false);

        IClassifierEstimateResult Average { get; }
    }
}