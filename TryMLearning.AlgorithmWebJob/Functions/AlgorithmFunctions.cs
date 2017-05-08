using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Model.Constants;

namespace TryMLearning.AlgorithmWebJob.Functions
{
    public class AlgorithmFunctions
    {
        private readonly IAlgorithmEstimationService _algorithmEstimationService;

        public AlgorithmFunctions(
            IAlgorithmEstimationService algorithmEstimationService)
        {
            _algorithmEstimationService = algorithmEstimationService;
        }

        public async Task RunClassifierEstimation([QueueTrigger(StorageQueueNames.ClassificationAlgorithm)] int algorithmEstimationId)
        {
            await _algorithmEstimationService.ExecuteClassifierEstimationAsync(algorithmEstimationId);
        }
    }
}
