using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;
using TryMLearning.Model.MachineLearning.Estimators;

namespace TryMLearning.Model.MachineLearning.EstimationResults.Classifier
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClassifierEstimationResultRequest
    {
        public int AlgorithmEstimationId { get; set; }

        public List<string> Estimates { get; set; }

        public FPErrorEstimateConfig FPErrorEstimateConfig { get; set; }

        public FNErrorEstimateConfig FNErrorEstimateConfig { get; set; }
    }
}
