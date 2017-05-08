using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;

namespace TryMLearning.Model.MachineLearning.Estimators
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class QFoldCrossValidationConfig : IQFoldCrossValidationConfig
    {
        public int QFold { get; set; }

        public int PrimaryFeatureIndex { get; set; }
    }
}