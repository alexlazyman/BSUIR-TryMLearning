using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AlgorithmEstimator
    {
        public AlgorithmEstimator()
        {
        }

        public AlgorithmEstimator(int algorithmEstimatorId)
        {
            AlgorithmEstimatorId = algorithmEstimatorId;
        }

        public int AlgorithmEstimatorId { get; set; }

        public string Alias { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}