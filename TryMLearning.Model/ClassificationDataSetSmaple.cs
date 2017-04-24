using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClassificationDataSetSmaple
    {
        public int ClassificationDataSetSmapleId { get; set; }

        public int DataSetId { get; set; }

        [JsonProperty("class")]
        public int ClassId { get; set; }

        [JsonProperty("vals")]
        public double[] Values { get; set; }
    }
}