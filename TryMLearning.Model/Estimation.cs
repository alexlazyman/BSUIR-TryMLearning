using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class Estimation
    {
        public int EstimationId { get; set; }

        public EstimationStatus Status { get; set; }

        public User User { get; set; }

        public EstimationAccessType Access { get; set; }

        public Algorithm Algorithm { get; set; }

        public DataSet DataSet { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }
    }
}
