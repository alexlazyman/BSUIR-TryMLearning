using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Statistics.Analysis;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.Default
{
    public class DefaultEstimate : BaseClassifierEstimate<ConfusionMatrix>
    {
        protected readonly DefaultConfig _config;

        public DefaultEstimate(DefaultConfig config)
        {
            _config = config;
        }

        protected override ConfusionMatrix Estimating(List<ClassificationResult> classificationResults)
        {
            int[] expected = classificationResults.Select(r => r.ExpectedClass).ToArray();
            int[] actual = classificationResults.Select(r => r.ActualClass).ToArray();

            var confusionMatrix = new ConfusionMatrix(actual, expected, _config.PrimaryClass);

            return confusionMatrix;
        }

        protected override EstimateResult GetAverageEstimate(List<ConfusionMatrix> estimateResults)
        {
            var estimateResult = new EstimateResult();

            var estimateTasks = new Dictionary<string, Func<List<ConfusionMatrix>, object>>();

            if (_config.FalsePositiveError)
            {
                estimateTasks.Add(nameof(DefaultConfig.FalsePositiveError), GetAverageFalsePositiveError);
            }

            if (_config.FalseNegativeError)
            {
                estimateTasks.Add(nameof(DefaultConfig.FalseNegativeError), GetAverageFalseNegativeError);
            }

            foreach (var estimateTask in estimateTasks)
            {
                var key = estimateTask.Key;
                var result = estimateTask.Value(estimateResults);

                estimateResult.Properties.Add(key, result);
            }

            return estimateResult;
        }

        private object GetAverageFalsePositiveError(List<ConfusionMatrix> estimateResults)
        {
            var fpe = estimateResults.Sum(r => r.NegativePredictiveValue) / estimateResults.Count;

            return fpe;
        }

        private object GetAverageFalseNegativeError(List<ConfusionMatrix> estimateResults)
        {
            var fne = estimateResults.Sum(r => r.PositivePredictiveValue) / estimateResults.Count;

            return fne;
        }
    }
}