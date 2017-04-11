using System.Collections.Generic;

namespace TryMLearning.Model.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }

        public bool IsValid => Errors.Count == 0;

        public List<ValidationError> Errors { get; set; }
    }
}