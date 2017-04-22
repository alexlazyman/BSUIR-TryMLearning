using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Algorithm
    {
        public int AlgorithmId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<AlgorithmParameter> Parameters { get; set; }
    }
}
