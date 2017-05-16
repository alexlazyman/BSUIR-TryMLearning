using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class Estimator
    {
        public Estimator()
        {
        }

        public Estimator(int estimatorId)
        {
            EstimatorId = estimatorId;
        }

        public int EstimatorId { get; set; }

        public string Alias { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}