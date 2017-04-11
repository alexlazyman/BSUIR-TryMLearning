using System.Collections.Generic;

namespace TryMLearning.Model
{
    public class AlgorithmSession
    {
        public int AlgorithmSessionId { get; set; }

        public int AlgorithmId { get; set; }

        public AlgorithmSessionStatus Status { get; set; }

        public List<AlgorithmParameterValue> ParameterValues { get; set; }
    }
}
