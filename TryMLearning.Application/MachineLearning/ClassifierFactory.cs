using System;
using Ninject;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model.Constants;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierFactory : IClassifierFactory
    {
        private readonly IKernel _container;

        public ClassifierFactory(IKernel container)
        {
            _container = container;
        }

        public IClassifier GetClassifier(string algorithmAlias)
        {
            var alias = algorithmAlias.ToUpper();
            switch (alias)
            {
                case AlgorithmAliases.NaiveBayes:
                    return _container.Get<IClassifier>(alias);
                default:
                    throw new ArgumentException($"There is no classifier with alias: {algorithmAlias}");
            }
        }
    }
}