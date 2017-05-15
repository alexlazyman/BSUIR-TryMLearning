using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Contexts
{
    public interface IUserContext
    {
        int? GetCurrentUserId();
    }
}