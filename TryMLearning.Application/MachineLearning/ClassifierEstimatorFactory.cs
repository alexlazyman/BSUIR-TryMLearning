using System;
using Ninject;
using Ninject.Parameters;
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
        private readonly IKernel _container;

        public ClassifierEstimatorFactory(IKernel container)
        {
            _container = container;
        }

        public IClassifierEstimator GetClassifierEstimator(AlgorithmEstimation algorithmEstimation)
        {
            var alias = algorithmEstimation.AlgorithmEstimator.Alias.ToUpper();
            switch (alias)
            {
                case ClassifierEstimatorAliases.QFoldCrossValidation:
                    return _container.Get<IClassifierEstimator>(alias, GetParameterOverride(algorithmEstimation.QFoldCrossValidationConfig));
                default:
                    throw new ArgumentException($"There is no test of classifier with alias: {algorithmEstimation.AlgorithmEstimator.Alias}");
            }
        }

        private IParameter[] GetParameterOverride<T>(T config)
        {
            return config == null
                ? new IParameter[0]
                : new IParameter[] { new ConstructorArgument("config", config) };
        }
    }
}