using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model.MachineLearning.EstimationResults.Classifier
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClassifierEstimationResult
    {
        public double? GeneralizationAbility { get; set; }

        public double? FalseNegativeError { get; set; }

        public double? FalsePositiveError { get; set; }
    }
}
