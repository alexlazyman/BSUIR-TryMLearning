using System;
using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Estimates;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning
{
    public class EstimateFactory : IEstimateFactory
    {
        private readonly IUnityContainer _container;

        public EstimateFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IEstimate GetEstimate(string estimateAlias)
        {
            var alias = estimateAlias.ToUpper();
            switch (alias)
            {
                case EstimateAliases.StandardError:
                    return _container.Resolve<IEstimate>(estimateAlias);
                default:
                    throw new ArgumentException($"There is no estimate with alias: {estimateAlias}");
            }
        }
    }
}