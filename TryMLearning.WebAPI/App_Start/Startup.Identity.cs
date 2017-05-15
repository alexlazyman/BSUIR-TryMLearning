using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using TryMLearning.Model;
using TryMLearning.WebAPI.Providers;

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public void ConfigureIdentity(IAppBuilder app)
        {
            app.CreatePerOwinContext<UserManager<User>>(CreateApplicationUserManager);
        }

        public UserManager<User> CreateApplicationUserManager(IdentityFactoryOptions<UserManager<User>> options, IOwinContext context)
        {
            var container = context.Get<IKernel>();
            var userStore = container.Get<IUserStore<User>>();

            var manager = new UserManager<User>(userStore);

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }
}
