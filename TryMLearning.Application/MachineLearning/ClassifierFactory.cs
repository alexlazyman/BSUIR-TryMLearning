using System;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model.Constants;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierFactory : IClassifierFactory
    {
        private readonly IUnityContainer _container;

        public ClassifierFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IClassifier GetClassifier(string algorithmAlias)
        {
            var alias = algorithmAlias.ToUpper();
            switch (alias)
            {
                case AlgorithmAliases.NaiveBayes:
                    return _container.Resolve<IClassifier>(alias);
                default:
                    throw new ArgumentException($"There is no classifier with alias: {algorithmAlias}");
            }
        }
    }
}