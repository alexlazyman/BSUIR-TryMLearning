namespace TryMLearning.Model
{
    public class AlgorithmParameterValue
    {
        public int AlgorithmParameterValueId { get; set; }

        public int AlgorithmParameterId { get; set; }

        public int AlgorithmSessionId { get; set; }

        public string Value { get; set; }
    }
}