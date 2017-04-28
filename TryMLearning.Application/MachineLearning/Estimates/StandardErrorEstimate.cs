using System.Collections.Generic;
using System.Linq;
using Accord.Math;
using TryMLearning.Application.Interface.MachineLearning.EstimateResults;
using TryMLearning.Application.Interface.MachineLearning.Estimates;
using TryMLearning.Application.MachineLearning.EstimateResults;

namespace TryMLearning.Application.MachineLearning.Estimates
{
    public class StandardErrorEstimate : IEstimate
    {
        private readonly List<StandardErrorEstimateResult> _results = new List<StandardErrorEstimateResult>();

        public int Count => _results.Count;

        public IEstimateResult Estimate(bool[] results, bool accumulate = false)
        {
            var standardError = (double) results.Count(r => !r) / results.Length;
            var result = new StandardErrorEstimateResult(standardError);

            if (accumulate)
            {
                _results.Add(result);
            }

            return result;
        }

        public IEstimateResult Average => GetAverage();

        private StandardErrorEstimateResult GetAverage()
        {
            var standardError = _results.Sum(r => r.StandardError) / _results.Count;

            return new StandardErrorEstimateResult(standardError);
        }
    }
}