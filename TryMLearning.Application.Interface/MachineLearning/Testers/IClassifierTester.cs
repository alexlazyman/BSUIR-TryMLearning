using System.Collections.Generic;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Testers
{
    public interface IClassifierTester
    {
        List<ClassificationResult> Classify(IEnumerable<ClassificationSample> samples, IClassifier classifier);

        List<EstimateResult> Estimate(List<ClassificationResult> classificationResults, List<IClassifierEstimate> estimates);
    }
}