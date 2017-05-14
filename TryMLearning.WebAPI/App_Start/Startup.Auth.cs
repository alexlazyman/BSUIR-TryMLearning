using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TryMLearning.WebAPI.App_Helpers;
using TryMLearning.WebAPI.Providers;

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var cookieAuthOptions = new CookieAuthenticationOptions();

            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new ApplicationOAuthProvider(),
                AllowInsecureHttp = true
            };

            app.UseCookieAuthentication(cookieAuthOptions);
            app.UseOAuthBearerTokens(oAuthOptions);
        }
    }
}
