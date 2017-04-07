using System.Collections.Generic;

namespace TryMLearning.Model
{
    public class Algorithm
    {
        public int AlgorithmId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<AlgorithmParameter> Parameters { get; set; }
    }
}
