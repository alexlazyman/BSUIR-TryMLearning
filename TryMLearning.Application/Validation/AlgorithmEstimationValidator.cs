using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmEstimationValidator : IValidator<AlgorithmEstimation>
    {
        public AlgorithmEstimationValidator()
        {
        }

        public Task<ValidationResult> ValidateAsync(AlgorithmEstimation entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}