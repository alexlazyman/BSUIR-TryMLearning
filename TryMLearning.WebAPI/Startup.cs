using System.Web.Http;
using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(TryMLearning.WebAPI.Startup))]

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            InitializeAutoMapper();

            app.CreatePerOwinContext(CreateKernel);
            app.UseNinjectMiddleware(CreateKernel);

            ConfigureIdentity(app);
            ConfigureAuth(app);

            var httpConfiguration = new HttpConfiguration();

            InitializeWebApi(httpConfiguration);
            InitializeSwagger(httpConfiguration);

            app.UseNinjectWebApi(httpConfiguration);
        }
    }
}
