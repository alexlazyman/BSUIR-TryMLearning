using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using TryMLearning.AlgorithmWebJob.Configuration;
using TryMLearning.AlgorithmWebJob.WebJob_Start;

namespace TryMLearning.AlgorithmWebJob
{
    public class Program
    {
        private static void Main()
        {
            AutoMapperConfig.Initialize();

            var container = new UnityContainer();
            container.RegisterComponents();

            var config = new JobHostConfiguration()
            {
                JobActivator = new JobActivator(container)
            };

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);

            host.RunAndBlock();
        }
    }
}
