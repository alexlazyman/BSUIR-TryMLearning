using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.MachineLearning;
using TryMLearning.Application.MachineLearning.Classifiers;
using TryMLearning.Application.MachineLearning.DataSetSampleStreams;
using TryMLearning.Application.Services;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
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
                .RegisterType<IAlgorithmParameterDao, AlgorithmParameterDao>(new HierarchicalLifetimeManager())
                .RegisterType<IAlgorithmSessionDao, AlgorithmSessionDao>(new HierarchicalLifetimeManager())
                
                .RegisterType<IDataSetDao, DataSetDao>(new HierarchicalLifetimeManager())
                .RegisterType<IDataSetSampleDao<ClassificationDataSetSmaple>, ClassificationDataSetSmapleDao>(new HierarchicalLifetimeManager())

                // Business Layer

                // Services
                .RegisterType<IAlgorithmService, AlgorithmService>(new HierarchicalLifetimeManager())
                .RegisterType<IAlgorithmSessionService, AlgorithmSessionService>(new HierarchicalLifetimeManager())
                
                .RegisterType<IDataSetService, DataSetService>(new HierarchicalLifetimeManager())
                .RegisterType<IDataSetSampleService<ClassificationDataSetSmaple>, ClassificationDataSetSampleService>(new HierarchicalLifetimeManager())

                // Valiation
                .RegisterType<IValidator<Algorithm>, AlgorithmValidator>(new HierarchicalLifetimeManager())
                .RegisterType<IValidator<AlgorithmParameter>, AlgorithmParameterValidator>(new HierarchicalLifetimeManager())
                .RegisterType<IValidator<AlgorithmSession>, AlgorithmSessionValidator>(new HierarchicalLifetimeManager())

                // Data set sample streams
                .RegisterType<IDataSetSampleStream<ClassificationDataSetSmaple>, ClassificationDataSetSampleStream>(new HierarchicalLifetimeManager())

                .RegisterType<IDataSetSampleStreamFactory, DataSetSampleStreamFactory>(new HierarchicalLifetimeManager())

                // Machine learning classifiers
                .RegisterType<IClassifier, NaiveBayesClassifier>(AlgorithmAliases.NaiveBayes, new HierarchicalLifetimeManager())
                
                .RegisterType<IClassifierFactory, ClassifierFactory>(new HierarchicalLifetimeManager());
        }
    }
}
