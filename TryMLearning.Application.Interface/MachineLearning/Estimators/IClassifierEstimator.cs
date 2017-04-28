using System.Collections.Generic;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.EstimateResults;
using TryMLearning.Application.Interface.MachineLearning.Estimates;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Reports;

namespace TryMLearning.Application.Interface.MachineLearning.Estimators
{
    public interface IClassifierEstimator
    {
        ClassificationReport Estimate(IClassifier classifier, ClassificationSample[] samples, string[] estimateAliases);
    }
}