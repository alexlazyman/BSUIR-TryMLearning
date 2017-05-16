using Microsoft.Azure.WebJobs.Host;
using Ninject;

namespace TryMLearning.AlgorithmWebJob.Configuration
{
    public class NinjectJobActivator : IJobActivator
    {
        private readonly IKernel _container;

        public NinjectJobActivator(IKernel container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Get<T>();
        }
    }
}