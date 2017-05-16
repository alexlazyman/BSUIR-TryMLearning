using System.Collections.Generic;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier
{
    public interface IClassifierEstimate
    {
        int Count { get; }

        void Estimate(List<ClassificationResult> classificationResults);

        EstimateResponse Average { get; }
    }
}