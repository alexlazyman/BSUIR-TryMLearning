using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Estimators
{
    public interface IClassifierEstimator
    {
        List<ClassificationResult> Classify(IEnumerable<ClassificationSample> samples, IClassifier classifier);

        List<IClassifierEstimateResult> Estimate(List<ClassificationResult> classificationResults, List<IClassifierEstimate> estimates);
    }
}