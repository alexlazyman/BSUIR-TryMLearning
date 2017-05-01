using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.Model.MachineLearning.Estimators.Configurations;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AlgorithmEstimate
    {
        public int AlgorithmEstimateId { get; set; }

        public AlgorithmEstimateStatus Status { get; set; }

        public Algorithm Algorithm { get; set; }

        public DataSet DataSet { get; set; }

        public Test Test { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }

        public QFoldCrossValidationConfiguration QFoldCrossValidationConfiguration { get; set; }
    }
}
