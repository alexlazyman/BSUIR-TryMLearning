using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Model;

namespace AlgorithmRunner
{
    public class Algorithms
    {
        public static void RunAlgorithm([QueueTrigger("algorithm")] AlgorithmRunConfig config)
        {
            Console.WriteLine(config.AlgorithmId);
            for (var i = 0; i < config.Parameters.Length; i++)
            {
                Console.WriteLine(config.Parameters[i].AlgorithmParameterId + " " + config.Parameters[i].Value);
            }
        }
    }
}
