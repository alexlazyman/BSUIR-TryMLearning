using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Ninject.Activation;
using TryMLearning.Application.Interface.Contexts;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.App_Infrastructure
{
    public class UserContext : IUserContext
    {
        public int? GetCurrentUserId()
        {
            var userId = HttpContext.Current.GetOwinContext()?.Authentication?.User?.Identity?.GetUserId();
            if (userId == null)
            {
                return null;
            }

            return int.Parse(userId);
        }
    }
}