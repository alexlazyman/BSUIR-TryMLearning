using System.Threading.Tasks;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmValidator : IValidator<Algorithm>
    {
        private readonly IValidator<AlgorithmParameter> _algorithmParameterValidator;

        public AlgorithmValidator(IValidator<AlgorithmParameter> algorithmParameterValidator)
        {
            _algorithmParameterValidator = algorithmParameterValidator;
        }

        public Task<ValidationResult> ValidateAsync(Algorithm entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}