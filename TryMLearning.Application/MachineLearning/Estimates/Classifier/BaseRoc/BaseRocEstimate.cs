using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Statistics.Analysis;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.BaseRoc
{
    public abstract class BaseRocEstimate : BaseClassifierEstimate<RocEstimateResult>
    {
        private const int PointsCount = 100;

        protected readonly RocConfig _config;

        protected BaseRocEstimate(RocConfig config)
        {
            _config = config;
        }

        protected override RocEstimateResult GetEstimateResult(List<ClassificationResult> classificationResults)
        {
            double[] expected = classificationResults.Select(r => r.ExpectedClass == _config.PrimaryClass ? 1.0 : 0.0).ToArray();
            double[] actual = classificationResults.Select(r => r.ActualClass == _config.PrimaryClass ? 1.0 : 0.0).ToArray();

            var roc = new ReceiverOperatingCharacteristic(expected, actual);

            roc.Compute(PointsCount);

            return new RocEstimateResult(roc.Points.ToArray());
        }
    }
}