using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model.MachineLearning.Estimates.Classifier
{
    public class RocConfig
    {
        public int PrimaryClass { get; set; }

        public bool Curve { get; set; }

        public bool Auc { get; set; }

        public bool StandardError { get; set; }

        public bool Variance { get; set; }
    }
}