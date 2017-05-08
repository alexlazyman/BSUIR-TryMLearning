using System;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Model.MachineLearning.Estimators;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierEstimatorFactory : IClassifierEstimatorFactory
    {
        private readonly IUnityContainer _container;

        public ClassifierEstimatorFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IClassifierEstimator GetClassifierEstimator(AlgorithmEstimation algorithmEstimation)
        {
            var alias = algorithmEstimation.AlgorithmEstimator.Alias.ToUpper();
            switch (alias)
            {
                case ClassifierEstimatorAliases.QFoldCrossValidation:
                    return _container.Resolve<IClassifierEstimator>(alias, GetParameterOverride(algorithmEstimation.QFoldCrossValidationConfig));
                default:
                    throw new ArgumentException($"There is no test of classifier with alias: {algorithmEstimation.AlgorithmEstimator.Alias}");
            }
        }

        private ResolverOverride[] GetParameterOverride<T>(T config)
        {
            return config == null
                ? new ResolverOverride[0]
                : new ResolverOverride[] { new ParameterOverride("config", config) };
        }
    }
}