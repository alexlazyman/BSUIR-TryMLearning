using TryMLearning.Model.MachineLearning.Estimators.Interfaces;

namespace TryMLearning.Model.MachineLearning.Estimators
{
    public class QFoldCrossValidationConfig : IQFoldCrossValidationConfig
    {
        public int QFold { get; set; }

        public int PrimaryFeatureIndex { get; set; }
    }
}