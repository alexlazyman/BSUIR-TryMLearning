using TryMLearning.Model.MachineLearning.Testers.Interfaces;

namespace TryMLearning.Model.MachineLearning.Testers
{
    public class QFoldCrossValidationConfig : IQFoldCrossValidationConfig
    {
        public int QFold { get; set; }

        public int PrimaryFeatureIndex { get; set; }
    }
}