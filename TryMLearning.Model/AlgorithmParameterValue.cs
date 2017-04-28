using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AlgorithmParameterValue
    {
        public int AlgorithmParameterValueId { get; set; }

        public int AlgorithmParameterId { get; set; }

        public int AlgorithmEstimateId { get; set; }

        public int? IntValue { get; set; }

        public double? DoubleValue { get; set; }

        public string StringValue { get; set; }
    }
}