namespace TryMLearning.Model.MachineLearning.Estimators.Interfaces
{
    public interface IQFoldCrossValidationConfig
    {
        int QFold { get; }

        int PrimaryFeatureIndex { get; }
    }
}