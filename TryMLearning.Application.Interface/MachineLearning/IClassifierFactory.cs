using TryMLearning.Application.Interface.MachineLearning.Classifiers;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierFactory
    {
        IClassifier GetClassifier(string algorithmAlias);
    }
}