using System.Collections.Generic;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierEstimateFactory
    {
        IClassifierEstimate GetEstimate(string estimateAlias, ClassifierEstimationResultRequest request);
    }
}