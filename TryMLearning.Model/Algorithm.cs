using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.Model.Constants;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Algorithm
    {
        public Algorithm()
        {
        }

        public Algorithm(int algorithmId)
        {
            AlgorithmId = algorithmId;
        }

        public int AlgorithmId { get; set; }

        public AlgorithmType Type { get; set; }

        public User Author { get; set; }

        public string Alias { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<AlgorithmParameter> Parameters { get; set; }
    }
}
