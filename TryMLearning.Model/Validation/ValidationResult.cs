using System.Collections.Generic;
using System.Linq;

namespace TryMLearning.Model.Validation
{
    public class ValidationResult
    {
        public static ValidationResult Invalid(params ValidationError[] errors) => new ValidationResult(errors);

        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }

        public ValidationResult(IEnumerable<ValidationError> errors)
        {
            Errors = errors.ToList();
        }

        public bool IsValid => Errors.Count == 0;

        public List<ValidationError> Errors { get; set; }
    }
}