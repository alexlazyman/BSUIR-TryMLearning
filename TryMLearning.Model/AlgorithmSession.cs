using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AlgorithmSession
    {
        public int AlgorithmSessionId { get; set; }

        public int AlgorithmId { get; set; }

        public int DataSetId { get; set; }

        public AlgorithmSessionStatus Status { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }
    }
}
