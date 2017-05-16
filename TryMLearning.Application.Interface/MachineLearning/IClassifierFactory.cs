using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IClassifierFactory
    {
        IClassifier GetClassifier(Algorithm algorithm);
    }
}