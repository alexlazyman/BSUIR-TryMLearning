namespace TryMLearning.Model.MachineLearning.Estimators.Configurations
{
    public class QFoldCrossValidationConfiguration
    {
        public QFoldCrossValidationConfiguration()
        {
            QFold = 10;
            PrimaryFeature = 0;
        }

        public int QFold { get; set; }

        public int PrimaryFeature { get; set; }
    }
}