namespace TryMLearning.Model.MachineLearning.Estimators.Configurations
{
    public class QFoldCrossValidationConfiguration
    {
        public QFoldCrossValidationConfiguration()
        {
            QFold = 10;
            PrimaryFeatureIndex = 0;
        }

        public int QFold { get; set; }

        public int PrimaryFeatureIndex { get; set; }
    }
}