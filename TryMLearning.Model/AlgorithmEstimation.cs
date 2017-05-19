using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class AlgorithmEstimation
    {
        public int AlgorithmEstimationId { get; set; }

        public AlgorithmEstimationStatus Status { get; set; }

        public User User { get; set; }

        public Algorithm Algorithm { get; set; }

        public DataSet DataSet { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }
    }
}
