using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.GeneralizationAbility
{
    public class GeneralizationAbilityResult
    {
        public double GeneralizationAbility { get; }

        public GeneralizationAbilityResult(double generalizationAbility)
        {
            GeneralizationAbility = generalizationAbility;
        }
    }
}