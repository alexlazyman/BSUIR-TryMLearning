using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmFormValidator : IValidator<AlgorithmForm>
    {
        public AlgorithmFormValidator()
        {
        }

        public Task<ValidationResult> ValidateAsync(AlgorithmForm entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}