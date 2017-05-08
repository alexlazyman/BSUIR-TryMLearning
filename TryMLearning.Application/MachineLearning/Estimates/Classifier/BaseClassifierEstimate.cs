using System.Collections.Generic;
using System.Linq;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier
{
    public abstract class BaseClassifierEstimate<T> : IClassifierEstimate
        where T : IClassifierEstimateResult
    {
        private readonly List<T> _estimateResults = new List<T>();

        public int Count => _estimateResults.Count;

        public IClassifierEstimateResult Estimate(List<ClassificationResult> classificationResults, bool accumulate = false)
        {
            var result = GetEstimateResult(classificationResults);

            if (accumulate)
            {
                _estimateResults.Add(result);
            }

            return result;
        }

        public IClassifierEstimateResult Average => GetAverageResult(_estimateResults);

        protected abstract T GetEstimateResult(List<ClassificationResult> classificationResults);

        protected abstract T GetAverageResult(List<T> estimateResults);
    }
}