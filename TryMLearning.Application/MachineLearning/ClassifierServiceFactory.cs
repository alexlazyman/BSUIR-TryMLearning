using System;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Model.MachineLearning.Estimators.Configurations;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierServiceFactory : IClassifierServiceFactory
    {
        private readonly IUnityContainer _container;

        public ClassifierServiceFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IClassifierService GetClassifierService(AlgorithmEstimate algorithmEstimate)
        {
            var alias = algorithmEstimate.Test.Alias.ToUpper();
            switch (alias)
            {
                case ClassifierTestAliases.QFoldCrossValidation:
                    return _container.Resolve<IClassifierService>(alias, new ParameterOverride("configuration", new InjectionParameter<QFoldCrossValidationConfiguration>(algorithmEstimate.QFoldCrossValidationConfiguration)));
                default:
                    throw new ArgumentException($"There is no test of classifier with alias: {algorithmEstimate.Test.Alias}");
            }
        }
    }
}