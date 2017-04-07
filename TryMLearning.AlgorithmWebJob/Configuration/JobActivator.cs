using Microsoft.Azure.WebJobs.Host;
using Microsoft.Practices.Unity;

namespace TryMLearning.AlgorithmWebJob.Configuration
{
    public class JobActivator : IJobActivator
    {
        private readonly IUnityContainer _container;

        public JobActivator(IUnityContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}