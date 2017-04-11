using System.Threading.Tasks;
using TryMLearning.Model.Validation;

namespace TryMLearning.Application.Interface.Validation
{
    public interface IValidator<in T>
    {
        Task<ValidationResult> ValidateAsync(T entity);
    }
}