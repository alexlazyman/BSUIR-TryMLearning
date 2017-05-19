using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Statistics.Analysis;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.Roc
{
    public class RocEstimate : BaseClassifierEstimate<ReceiverOperatingCharacteristic>
    {
        protected readonly RocConfig _config;

        public RocEstimate(RocConfig config)
        {
            _config = config;
        }

        protected override ReceiverOperatingCharacteristic Estimating(List<ClassificationResult> classificationResults)
        {
            double[] expected = classificationResults.Select(r => r.ExpectedClass == _config.PrimaryClass ? 1.0 : 0.0).ToArray();
            double[] actual = classificationResults.Select(r => r.ActualClass == _config.PrimaryClass ? 1.0 : 0.0).ToArray();

            var roc = new ReceiverOperatingCharacteristic(expected, actual);

            roc.Compute(classificationResults.Count);

            return roc;
        }

        protected override EstimateResult GetAverageEstimate(List<ReceiverOperatingCharacteristic> estimateResults)
        {
            var estimateResult = new EstimateResult();

            var estimateTasks = new Dictionary<string, Func<List<ReceiverOperatingCharacteristic>, object>>();

            if (_config.Curve)
            {
                estimateTasks.Add(nameof(RocConfig.Curve), GetAverageRocCurve);
            }

            if (_config.StandardError)
            {
                estimateTasks.Add(nameof(RocConfig.StandardError), GetAverageStandardError);
            }

            if (_config.Variance)
            {
                estimateTasks.Add(nameof(RocConfig.Variance), GetAverageVariance);
            }

            if (_config.Auc)
            {
                estimateTasks.Add(nameof(RocConfig.Auc), GetAverageAuc);
            }

            foreach (var estimateTask in estimateTasks)
            {
                var key = estimateTask.Key;
                var result = estimateTask.Value(estimateResults);

                estimateResult.Properties.Add(key, result);
            }

            return estimateResult;
        }

        private object GetAverageRocCurve(List<ReceiverOperatingCharacteristic> estimateResults)
        {
            var pointsCount = estimateResults.First().Points.Count;

            var tuples = new Tuple<double, double>[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                var fpr = estimateResults.Sum(r => r.Points[i].FalsePositiveRate) / estimateResults.Count;
                var sens = estimateResults.Sum(r => r.Points[i].Sensitivity) / estimateResults.Count;

                tuples[i] = Tuple.Create(fpr, sens);
            }

            return tuples.Select(t => new
            {
                Fpr = t.Item1,
                Sens = t.Item2
            }).ToList();
        }

        private object GetAverageStandardError(List<ReceiverOperatingCharacteristic> estimateResults)
        {
            var standardError = estimateResults.Sum(r => r.StandardError) / estimateResults.Count;

            return standardError;
        }

        private object GetAverageVariance(List<ReceiverOperatingCharacteristic> estimateResults)
        {
            var standardError = estimateResults.Sum(r => r.Variance) / estimateResults.Count;

            return standardError;
        }

        private object GetAverageAuc(List<ReceiverOperatingCharacteristic> estimateResults)
        {
            var standardError = estimateResults.Sum(r => r.Area) / estimateResults.Count;

            return standardError;
        }
    }
}