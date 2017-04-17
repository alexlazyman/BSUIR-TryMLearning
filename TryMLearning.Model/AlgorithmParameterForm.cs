using System.Collections.Generic;

namespace TryMLearning.Model
{
    public class AlgorithmParameterForm
    {
        public int AlgorithmParameterId { get; set; }

        public int? IntValue { get; set; }

        public double? DoubleValue { get; set; }

        public string StringValue { get; set; }
    }
}
