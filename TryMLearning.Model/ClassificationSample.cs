using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class ClassificationSample
    {
        public int ClassificationSampleId { get; set; }

        public int DataSetId { get; set; }

        public int ClassId { get; set; }

        public double[] Features { get; set; }
    }
}