using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.GeneralizationAbility
{
    public class GeneralizationAbilityResult : IClassifierEstimateResult
    {
        public double GeneralizationAbility { get; }

        public GeneralizationAbilityResult(double generalizationAbility)
        {
            GeneralizationAbility = generalizationAbility;
        }

        public void Render(ClassifierEstimationResult classifierEstimationResult)
        {
            classifierEstimationResult.GeneralizationAbility = GeneralizationAbility;
        }
    }
}