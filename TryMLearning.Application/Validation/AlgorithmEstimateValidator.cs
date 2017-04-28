using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmEstimateValidator : IValidator<AlgorithmEstimate>
    {
        public AlgorithmEstimateValidator()
        {
        }

        public Task<ValidationResult> ValidateAsync(AlgorithmEstimate entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}