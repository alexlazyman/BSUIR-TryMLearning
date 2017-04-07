using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Services;
using TryMLearning.Persistence;
using TryMLearning.Persistence.Daos;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.AlgorithmWebJob.WebJob_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(this UnityContainer container)
        {
            container

                // Data Access Layer

                // Infrastructure
                .RegisterType<TryMLearningDbContext>(new HierarchicalLifetimeManager())

                // Daos
                .RegisterType<IAlgorithmDao, AlgorithmDao>(new HierarchicalLifetimeManager())
                .RegisterType<IAlgorithmSessionDao, AlgorithmSessionDao>(new HierarchicalLifetimeManager())

                // Business Layer

                // Services
                .RegisterType<IAlgorithmService, AlgorithmService>(new HierarchicalLifetimeManager())
                .RegisterType<IAlgorithmSessionService, AlgorithmSessionService>(new HierarchicalLifetimeManager());
        }
    }
}