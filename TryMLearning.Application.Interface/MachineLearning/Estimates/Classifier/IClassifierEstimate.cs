using System.Collections.Generic;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier
{
    public interface IClassifierEstimate
    {
        void Estimate(List<ClassificationResult> classificationResults);

        EstimateResult GetAverageEstimate();
    }
}