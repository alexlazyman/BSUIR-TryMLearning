using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AlgorithmEstimate
    {
        public int AlgorithmEstimateId { get; set; }

        public int AlgorithmId { get; set; }

        public int DataSetId { get; set; }

        public AlgorithmEstimateStatus Status { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }

        public List<string> Estimates { get; set; }
    }
}
