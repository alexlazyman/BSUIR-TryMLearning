using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClassificationSample
    {
        public int ClassificationDataSetSampleId { get; set; }

        public int DataSetId { get; set; }

        [JsonProperty("class")]
        public int ClassId { get; set; }

        public double[] Features { get; set; }
    }
}