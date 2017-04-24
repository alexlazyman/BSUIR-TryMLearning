using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Model.Constants;

namespace TryMLearning.AlgorithmWebJob.Functions
{
    public class AlgorithmFunctions
    {
        private readonly IAlgorithmService _algorithmService;

        public AlgorithmFunctions(
            IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        public async void RunClassificationAlgorithm([QueueTrigger(StorageQueueNames.ClassificationAlgorithm)] int algorithmSessionId)
        {
            await _algorithmService.ComputeClassificationAlgorithmAsync(algorithmSessionId);
        }
    }
}
