using System;
using Microsoft.AspNet.Identity;
using Ninject;
using Ninject.Web.Common;
using TryMLearning.Application.Interface.Contexts;
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
using TryMLearning.Application.MachineLearning.Estimates.Classifier.RocCurve;
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
using TryMLearning.WebAPI.App_Infrastructure;

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            // Data Access Layer

            // Infrastructure
            kernel.Bind<TryMLearningDbContext>().ToSelf().InRequestScope();
            kernel.Bind<ITransactionScope>().To<TransactionScope>();

            // Daos
            kernel.Bind<IAlgorithmDao>().To<AlgorithmDao>();
            kernel.Bind<IAlgorithmParameterDao>().To<AlgorithmParameterDao>();
            kernel.Bind<IAlgorithmParameterValueDao>().To<AlgorithmParameterValueDao>();
            kernel.Bind<IAlgorithmEstimationDao>().To<AlgorithmEstimationDao>();
            kernel.Bind<IEstimatorDao>().To<EstimatorDao>();
            kernel.Bind<IClassificationResultDao>().To<ClassificationResultDao>();
            kernel.Bind<IUserDao>().To<UserDao>();
            kernel.Bind<IDataSetDao>().To<DataSetDao>();
            kernel.Bind<ISampleDao<ClassificationSample>>().To<ClassificationSampleDao>();

            // Identity
            kernel.Bind<IUserStore<User>>().To<UserStore>();
            kernel.Bind<IUserContext>().To<UserContext>();

            // Services
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IAlgorithmService>().To<AlgorithmService>();
            kernel.Bind<IAlgorithmEstimationService>().To<AlgorithmEstimationService>();
            kernel.Bind<IEstimatorService>().To<EstimatorService>();
            kernel.Bind<IDataSetService>().To<DataSetService>();
            kernel.Bind<ISampleService<ClassificationSample>>().To<ClassificationSampleService>();
            kernel.Bind<IClassificationResultService>().To<ClassificationResultService>();

            // Valiation
            kernel.Bind<IValidator<Algorithm>>().To<AlgorithmValidator>();
            kernel.Bind<IValidator<AlgorithmParameter>>().To<AlgorithmParameterValidator>();
            kernel.Bind<IValidator<AlgorithmEstimation>>().To<AlgorithmEstimationValidator>();

            // Machine learning

            kernel.Bind<IClassificationContext>().To<ClassificationContext>();

            // Clasificators
            kernel.Bind<IClassifier>().To<NaiveBayesClassifier>().Named($"{AlgorithmType.Classifier}:{AlgorithmAliases.NaiveBayes}");

            // Estimators
            kernel.Bind<IClassifierEstimator>().To<QFoldCrossValidation>().Named(ClassifierEstimatorAliases.QFoldCrossValidation);

            kernel.Bind<IQFoldCrossValidationConfig>().To<DefaultQFoldCrossValidationConfig>();

            // Estimates
            kernel.Bind<IClassifierEstimate>().To<GeneralizationAbility>().Named(ClassifierEstimateAliases.GeneralizationAbility);
            kernel.Bind<IClassifierEstimate>().To<FalseNegativeError>().Named(ClassifierEstimateAliases.FalseNegativeError);
            kernel.Bind<IClassifierEstimate>().To<FalsePositiveError>().Named(ClassifierEstimateAliases.FalsePositiveError);
            kernel.Bind<IClassifierEstimate>().To<RocCurve>().Named(ClassifierEstimateAliases.RocCurves);
            
            kernel.Bind<IClassifierFactory>().To<ClassifierFactory>();
            kernel.Bind<IClassifierEstimatorFactory>().To<ClassifierEstimatorFactory>();
            kernel.Bind<IClassifierEstimateFactory>().To<ClassifierEstimateFactory>();

            return kernel;
        }
    }
}