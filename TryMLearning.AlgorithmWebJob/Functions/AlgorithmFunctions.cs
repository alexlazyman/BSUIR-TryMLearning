using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model.Constants;

namespace TryMLearning.AlgorithmWebJob.Functions
{
    public class AlgorithmFunctions
    {
        private readonly IAlgorithmSessionService _algorithmSessionService;

        public AlgorithmFunctions(IAlgorithmSessionService algorithmSessionService)
        {
            _algorithmSessionService = algorithmSessionService;
        }

        public async void RunAlgorithm([QueueTrigger(StorageQueueNames.Algorithm)] int algorithmSessionId)
        {
            var algorithmSession = await _algorithmSessionService.GetAlgorithmSessionAsync(algorithmSessionId);

            // If algorithmSession is null, then should reencueue message (about 3 times).

            Console.WriteLine($"AlgId - {algorithmSession.AlgorithmId}");
            Console.WriteLine($"Status - {algorithmSession.Status}");
            Console.WriteLine($"Params - {algorithmSession.ParameterValues.Aggregate("", (r, p) => r + " " + p.Value)}");
        }
    }
}
