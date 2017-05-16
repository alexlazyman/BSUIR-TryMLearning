using System.Collections.Generic;
using System.Linq;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.GeneralizationAbility
{
    public class GeneralizationAbility : BaseClassifierEstimate<GeneralizationAbilityResult>
    {
        protected override GeneralizationAbilityResult GetEstimateResult(List<ClassificationResult> classificationResults)
        {
            var generalizationAbility = (double)classificationResults.Count(r => r.ActualClass == r.ExpectedClass) / classificationResults.Count;

            return new GeneralizationAbilityResult(generalizationAbility);
        }

        protected override EstimateResponse GetAverageResult(List<GeneralizationAbilityResult> estimateResults)
        {
            var generalizationAbility = estimateResults.Sum(r => r.GeneralizationAbility) / estimateResults.Count;

            return new EstimateResponse
            {
                Value = generalizationAbility
            };
        }
    }
}