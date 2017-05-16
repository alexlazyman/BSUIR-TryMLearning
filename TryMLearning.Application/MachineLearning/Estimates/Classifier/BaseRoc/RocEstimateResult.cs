using System.Linq;
using Accord.Statistics.Analysis;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.BaseRoc
{
    public class RocEstimateResult
    {
        public ReceiverOperatingCharacteristicPoint[] Points { get; }

        public RocEstimateResult(ReceiverOperatingCharacteristicPoint[] points)
        {
            Points = points;
        }
    }
}