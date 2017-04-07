using Microsoft.Practices.Unity;
using System.Web.Http;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Services;
using TryMLearning.Persistence;
using TryMLearning.Persistence.Interface.Repositories;
using TryMLearning.Persistence.Repositories;
using Unity.WebApi;

namespace TryMLearning.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container

                // Data Access Layer

                // Infrastructure
                .RegisterType<TryMLearningDbContext>(new HierarchicalLifetimeManager())

                // Repositories
                .RegisterType<IAlgorithmRepository, AlgorithmRepository>(new HierarchicalLifetimeManager())

                // Business Layer

                // Services
                .RegisterType<IAlgorithmService, AlgorithmService>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}