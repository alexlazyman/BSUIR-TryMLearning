using System.Collections.Generic;

namespace TryMLearning.Model
{
    public class EstimateResult
    {
        public Dictionary<string, object> Properties { get; set; }

        public EstimateResult()
        {
            Properties = new Dictionary<string, object>();
        }
    }
}