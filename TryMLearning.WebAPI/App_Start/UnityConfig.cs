using Microsoft.Practices.Unity;
using System.Web.Http;
using TryMLearning.Configuration;
using Unity.WebApi;

namespace TryMLearning.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterCommonComponents();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}