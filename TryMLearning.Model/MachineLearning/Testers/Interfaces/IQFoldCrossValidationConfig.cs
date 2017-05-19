namespace TryMLearning.Model.MachineLearning.Testers.Interfaces
{
    public interface IQFoldCrossValidationConfig
    {
        int QFold { get; }

        int PrimaryFeatureIndex { get; }
    }
}