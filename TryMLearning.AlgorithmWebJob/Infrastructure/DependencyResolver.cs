using Ninject;
using TryMLearning.AlgorithmWebJob.Contexts;
using TryMLearning.Application.Interface.Contexts;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.MachineLearning.Testers;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.MachineLearning;
using TryMLearning.Application.MachineLearning.Classifiers;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.Default;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.Roc;
using TryMLearning.Application.MachineLearning.Testers;
using TryMLearning.Application.Services;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Model.MachineLearning.Testers;
using TryMLearning.Model.MachineLearning.Testers.Interfaces;
using TryMLearning.Persistence;
using TryMLearning.Persistence.Daos;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.AlgorithmWebJob.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            var container = CreateKernel();

            return new DependencyScope(container);
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            // Data Access Layer

            // Infrastructure
            kernel.Bind<TryMLearningDbContext>().ToSelf().InSingletonScope();
            kernel.Bind<ITransactionScope>().To<TransactionScope>();

            // Daos
            kernel.Bind<IAlgorithmDao>().To<AlgorithmDao>();
            kernel.Bind<IAlgorithmParameterDao>().To<AlgorithmParameterDao>();
            kernel.Bind<IAlgorithmParameterValueDao>().To<AlgorithmParameterValueDao>();
            kernel.Bind<IAlgorithmEstimationDao>().To<AlgorithmEstimationDao>();
            kernel.Bind<IClassificationResultDao>().To<ClassificationResultDao>();
            kernel.Bind<IUserDao>().To<UserDao>();
            kernel.Bind<IDataSetDao>().To<DataSetDao>();
            kernel.Bind<ISampleDao<ClassificationSample>>().To<ClassificationSampleDao>();

            // Identity
            kernel.Bind<IUserContext>().To<UserContext>();

            // Services
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IAlgorithmService>().To<AlgorithmService>();
            kernel.Bind<IAlgorithmEstimationService>().To<AlgorithmEstimationService>();
            kernel.Bind<IDataSetService>().To<DataSetService>();
            kernel.Bind<ISampleService<ClassificationSample>>().To<ClassificationSampleService>();
            kernel.Bind<IClassificationResultService>().To<ClassificationResultService>();

            // Valiation
            kernel.Bind<IValidator<Algorithm>>().To<AlgorithmValidator>();
            kernel.Bind<IValidator<AlgorithmParameter>>().To<AlgorithmParameterValidator>();
            kernel.Bind<IValidator<AlgorithmEstimation>>().To<AlgorithmEstimationValidator>();

            // Machine learning

            // Clasificators
            kernel.Bind<IClassifier>().To<NaiveBayesClassifier>().Named(AlgorithmAliases.NaiveBayes);

            // Testers
            kernel.Bind<IClassifierTester>().To<QFoldCrossValidation>();

            kernel.Bind<IQFoldCrossValidationConfig>().To<DefaultQFoldCrossValidationConfig>();

            // Estimates
            kernel.Bind<IClassifierEstimate>().To<DefaultEstimate>().Named(ClassifierEstimateAliases.Default);
            kernel.Bind<IClassifierEstimate>().To<RocEstimate>().Named(ClassifierEstimateAliases.Roc);

            kernel.Bind<IClassifierFactory>().To<ClassifierFactory>();
            kernel.Bind<IClassifierEstimateFactory>().To<ClassifierEstimateFactory>();

            return kernel;
        }
    }
}