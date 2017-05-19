using System.Collections.Generic;
using System.Linq;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier
{
    public abstract class BaseClassifierEstimate<T> : IClassifierEstimate
    {
        private readonly List<T> _estimateResults = new List<T>();

        public int Count => _estimateResults.Count;

        public void Estimate(List<ClassificationResult> classificationResults)
        {
            var result = Estimating(classificationResults);

            _estimateResults.Add(result);
        }

        public EstimateResult GetAverageEstimate()
        {
            return GetAverageEstimate(_estimateResults);
        }

        protected abstract T Estimating(List<ClassificationResult> classificationResults);

        protected abstract EstimateResult GetAverageEstimate(List<T> estimateResults);
    }
}