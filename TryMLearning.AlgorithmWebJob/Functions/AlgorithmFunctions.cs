using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Persistence.Constants;

namespace TryMLearning.AlgorithmWebJob
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

            Console.WriteLine($"AlgId - {algorithmSession.AlgorithmId}");
            Console.WriteLine($"Status - {algorithmSession.Status}");
            Console.WriteLine($"Params - {algorithmSession.Parameters.Aggregate("", (r, p) => r + " " + p.Value)}");
        }
    }
}
