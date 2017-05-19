using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model.MachineLearning.Estimates.Classifier
{
    public class DefaultConfig
    {
        public int PrimaryClass { get; set; }

        public bool FalsePositiveError { get; set; }

        public bool FalseNegativeError { get; set; }
    }
}