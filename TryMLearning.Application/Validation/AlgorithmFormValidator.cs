using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class AlgorithmFormValidator : IValidator<AlgorithmForm>
    {
        private readonly IAlgorithmService _algorithmService;

        public AlgorithmFormValidator(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        public Task<ValidationResult> ValidateAsync(AlgorithmForm entity)
        {
            // TODO: Implement validation
            return Task.FromResult(new ValidationResult());
        }
    }
}