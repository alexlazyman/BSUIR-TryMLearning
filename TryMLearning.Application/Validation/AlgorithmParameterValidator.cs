using System.Threading.Tasks;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmParameterValidator : IValidator<AlgorithmParameter>
    {
        public Task<ValidationResult> ValidateAsync(AlgorithmParameter entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}