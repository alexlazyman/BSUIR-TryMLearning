using System;
using Ninject;
using Ninject.Parameters;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierEstimateFactory : IClassifierEstimateFactory
    {
        private readonly IKernel _container;

        public ClassifierEstimateFactory(IKernel container)
        {
            _container = container;
        }

        public IClassifierEstimate GetEstimate(string estimateAlias, ClassifierEstimationResultRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var alias = estimateAlias.ToUpper();
            switch (alias)
            {
                case ClassifierEstimateAliases.GeneralizationAbility:
                    return _container.Get<IClassifierEstimate>(estimateAlias);
                case ClassifierEstimateAliases.FalsePositiveError:
                    if (request.FNErrorEstimateConfig == null)
                    {
                        throw new ArgumentNullException(nameof(request.FPErrorEstimateConfig));
                    }

                    return _container.Get<IClassifierEstimate>(estimateAlias,
                        GetParameterOverride(request.FPErrorEstimateConfig));
                case ClassifierEstimateAliases.FalseNegativeError:
                    if (request.FNErrorEstimateConfig == null)
                    {
                        throw new ArgumentNullException(nameof(request.FNErrorEstimateConfig));
                    }

                    return _container.Get<IClassifierEstimate>(estimateAlias,
                        GetParameterOverride(request.FNErrorEstimateConfig));
                default:
                    throw new ArgumentException($"There is no estimate with alias: {estimateAlias}");
            }
        }

        private IParameter[] GetParameterOverride<T>(T config)
        {
            return new IParameter[] { new ConstructorArgument("config", config) };
        }
    }
}