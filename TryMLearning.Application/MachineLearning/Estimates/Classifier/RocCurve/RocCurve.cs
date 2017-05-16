using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Statistics.Analysis;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.BaseRoc;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.RocCurve
{
    public class RocCurve : BaseRocEstimate
    {
        public RocCurve(RocConfig config)
            : base(config)
        {
        }

        protected override EstimateResponse GetAverageResult(List<RocEstimateResult> estimateResults)
        {
            var count = estimateResults.First().Points.Length;

            var tuples = new List<Tuple<double, double>>(count);

            for (int i = 0; i < count; i++)
            {
                var fpr = (double) estimateResults.Sum(r => r.Points[i].FalsePositiveRate) / estimateResults.Count;
                var sens = (double) estimateResults.Sum(r => r.Points[i].Sensitivity) / estimateResults.Count;

                tuples.Add(Tuple.Create(fpr, sens));
            }

            return new EstimateResponse
            {
                Value = tuples.Select(t => new
                {
                    V1 = t.Item1,
                    V2 = t.Item2
                }).ToList()
            };
        }
    }
}