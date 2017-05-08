using System;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.MachineLearning
{
    public class ClassifierEstimateFactory : IClassifierEstimateFactory
    {
        private readonly IUnityContainer _container;

        public ClassifierEstimateFactory(IUnityContainer container)
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
                    return _container.Resolve<IClassifierEstimate>(estimateAlias);
                case ClassifierEstimateAliases.FalsePositiveError:
                    if (request.FNErrorEstimateConfig == null)
                    {
                        throw new ArgumentNullException(nameof(request.FPErrorEstimateConfig));
                    }

                    return _container.Resolve<IClassifierEstimate>(estimateAlias,
                        GetParameterOverride(request.FPErrorEstimateConfig));
                case ClassifierEstimateAliases.FalseNegativeError:
                    if (request.FNErrorEstimateConfig == null)
                    {
                        throw new ArgumentNullException(nameof(request.FNErrorEstimateConfig));
                    }

                    return _container.Resolve<IClassifierEstimate>(estimateAlias,
                        GetParameterOverride(request.FNErrorEstimateConfig));
                default:
                    throw new ArgumentException($"There is no estimate with alias: {estimateAlias}");
            }
        }

        private ResolverOverride[] GetParameterOverride<T>(T config)
        {
            return new ResolverOverride[] { new ParameterOverride("config", config) };
        }
    }
}