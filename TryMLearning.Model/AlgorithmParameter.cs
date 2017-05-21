using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class AlgorithmParameter
    {
        public int AlgorithmParameterId { get; set; }

        public int AlgorithmId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AlgorithmParameterType ValueType { get; set; }
    }
}
