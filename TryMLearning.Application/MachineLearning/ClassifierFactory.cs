using System;
using Ninject;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model;
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

        public IClassifier GetClassifier(Algorithm algorithm)
        {
            var alias = algorithm.Alias;

            var classifier = _container.TryGet<IClassifier>(alias);
            if (classifier == null)
            {
                throw new ArgumentException($"There is no classifier with alias: {algorithm.Alias}");
            }

            return classifier;
        }
    }
}