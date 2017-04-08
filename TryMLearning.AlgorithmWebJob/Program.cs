using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using TryMLearning.AlgorithmWebJob.Configuration;
using TryMLearning.Configuration;

namespace TryMLearning.AlgorithmWebJob
{
    public class Program
    {
        private static void Main()
        {
            // AutoMapper initialization.
            Mapper.Initialize(cfg =>
            {
                cfg.RegisterCommonMaps();
            });

            // Unity initialization.
            var container = new UnityContainer();
            container.RegisterCommonComponents();
            var unityJobActivator = new UnityJobActivator(container);

            // WebJon initialization.
            var config = new JobHostConfiguration()
            {
                JobActivator = unityJobActivator
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
