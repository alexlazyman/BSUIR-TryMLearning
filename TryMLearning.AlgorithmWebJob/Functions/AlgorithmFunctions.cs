using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Ninject;
using TryMLearning.AlgorithmWebJob.Infrastructure;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Model.Constants;

namespace TryMLearning.AlgorithmWebJob.Functions
{
    public class AlgorithmFunctions
    {
        private readonly IDependencyResolver _dependencyResolver;

        public AlgorithmFunctions(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public async Task RunClassifierEstimation([QueueTrigger(StorageQueueNames.ClassificationAlgorithm)] int estimationId)
        {
            using (var sope = _dependencyResolver.BeginScope())
            {
                var estimationService = sope.Get<IEstimationService>();

                await estimationService.ExecuteClassifierEstimationAsync(estimationId);
            }
        }
    }
}
