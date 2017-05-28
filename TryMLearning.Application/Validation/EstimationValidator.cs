using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Validation
{
    public class EstimationValidator : IValidator<Estimation>
    {
        public EstimationValidator()
        {
        }

        public async Task<ValidationResult> ValidateAsync(Estimation estimation)
        {
            var validationResult = new ValidationResult();

            if (estimation == null)
            {
                return ValidationResult.Invalid(new ValidationError(nameof(estimation), "Estimation required"));
            }

            if (estimation.Algorithm == null || estimation.Algorithm.AlgorithmId < 0)
            {
                return ValidationResult.Invalid(new ValidationError(nameof(estimation.Algorithm), "Algorithm required"));
            }

            if (estimation.DataSet == null || estimation.DataSet.DataSetId < 0)
            {
                return ValidationResult.Invalid(new ValidationError(nameof(estimation.DataSet), "DataSet required"));
            }

            return validationResult;
        }
    }
}