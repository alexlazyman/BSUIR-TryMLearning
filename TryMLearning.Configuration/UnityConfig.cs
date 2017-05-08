using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Contexts;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.MachineLearning;
using TryMLearning.Application.MachineLearning.Classifiers;
using TryMLearning.Application.MachineLearning.Contexts;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.FalseNegativeError;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.FalsePositiveError;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.GeneralizationAbility;
using TryMLearning.Application.MachineLearning.Estimators;
using TryMLearning.Application.Services;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;
using TryMLearning.Model.MachineLearning.Estimators;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;
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
                .RegisterType<IAlgorithmEstimationDao, AlgorithmEstimationDao>(new HierarchicalLifetimeManager())
                
                .RegisterType<IClassificationResultDao, ClassificationResultDao>(new HierarchicalLifetimeManager())
                
                .RegisterType<IDataSetDao, DataSetDao>(new HierarchicalLifetimeManager())
                .RegisterType<ISampleDao<ClassificationSample>, ClassificationSampleDao>(new HierarchicalLifetimeManager())

                // Business Layer

                // Services
                .RegisterType<IAlgorithmService, AlgorithmService>(new HierarchicalLifetimeManager())
                .RegisterType<IAlgorithmEstimationService, AlgorithmEstimationService>(new HierarchicalLifetimeManager())

                .RegisterType<IDataSetService, DataSetService>(new HierarchicalLifetimeManager())
                .RegisterType<ISampleService<ClassificationSample>, ClassificationSampleService>(new HierarchicalLifetimeManager())

                .RegisterType<IClassificationResultService, ClassificationResultService>(new HierarchicalLifetimeManager())

                // Valiation
                .RegisterType<IValidator<Algorithm>, AlgorithmValidator>(new HierarchicalLifetimeManager())
                .RegisterType<IValidator<AlgorithmParameter>, AlgorithmParameterValidator>(new HierarchicalLifetimeManager())
                .RegisterType<IValidator<AlgorithmEstimation>, AlgorithmEstimationValidator>(new HierarchicalLifetimeManager())

                // Machine learning
                
                .RegisterType<IClassificationContext, ClassificationContext>(new HierarchicalLifetimeManager())

                // Clasificators
                .RegisterType<IClassifier, NaiveBayesClassifier>(AlgorithmAliases.NaiveBayes, new HierarchicalLifetimeManager())

                // Estimators
                .RegisterType<IClassifierEstimator, QFoldCrossValidation>(ClassifierEstimatorAliases.QFoldCrossValidation, new HierarchicalLifetimeManager())

                .RegisterType<IQFoldCrossValidationConfig, DefaultQFoldCrossValidationConfig>(new HierarchicalLifetimeManager())

                // Estimates
                .RegisterType<IClassifierEstimate, GeneralizationAbility>(ClassifierEstimateAliases.GeneralizationAbility, new HierarchicalLifetimeManager())
                .RegisterType<IClassifierEstimate, FalseNegativeError>(ClassifierEstimateAliases.FalseNegativeError, new HierarchicalLifetimeManager())
                .RegisterType<IClassifierEstimate, FalsePositiveError>(ClassifierEstimateAliases.FalsePositiveError, new HierarchicalLifetimeManager())

                .RegisterType<IClassifierFactory, ClassifierFactory>(new HierarchicalLifetimeManager())
                .RegisterType<IClassifierEstimatorFactory, ClassifierEstimatorFactory>(new HierarchicalLifetimeManager())
                .RegisterType<IClassifierEstimateFactory, ClassifierEstimateFactory>(new HierarchicalLifetimeManager());
        }
    }
}
