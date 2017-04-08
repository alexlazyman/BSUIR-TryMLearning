using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Services;
using TryMLearning.Persistence;
using TryMLearning.Persistence.Daos;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Configuration
{
    public static class UnityConfig
    {
        public static void RegisterCommonComponents(this UnityContainer container)
        {
            container

                // Data Access Layer

                // Infrastructure
                .RegisterType<TryMLearningDbContext>(new HierarchicalLifetimeManager())
                .RegisterType<ITransactionScope, TransactionScope>(new HierarchicalLifetimeManager())

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
