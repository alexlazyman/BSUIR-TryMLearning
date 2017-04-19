using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmSessionValidator : IValidator<AlgorithmSession>
    {
        public AlgorithmSessionValidator()
        {
        }

        public Task<ValidationResult> ValidateAsync(AlgorithmSession entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}