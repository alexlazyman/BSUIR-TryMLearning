using AutoMapper;
using Microsoft.Azure.WebJobs;
using Ninject;
using TryMLearning.AlgorithmWebJob.Configuration;

namespace TryMLearning.AlgorithmWebJob
{
    public partial class Program
    {
        private static void Main()
        {
            // AutoMapper initialization.
            InitializeAutoMapper();

            // Unity initialization.
            var container = CreateKernel();

            // WebJon initialization.
            var config = new JobHostConfiguration()
            {
                JobActivator = new NinjectJobActivator(container)
            };

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);

            // Run continuously.
            host.RunAndBlock();
        }
    }
}
