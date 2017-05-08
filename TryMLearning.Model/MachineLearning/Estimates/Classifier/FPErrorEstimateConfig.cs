using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model.MachineLearning.Estimates.Classifier
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class FPErrorEstimateConfig
    {
        public int PrimaryClass { get; set; }
    }
}