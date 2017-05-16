using Ninject;

namespace TryMLearning.AlgorithmWebJob.Infrastructure
{
    public class DependencyScope : IDependencyScope
    {
        private readonly IKernel _container;

        public DependencyScope(IKernel container)
        {
            _container = container;
        }

        public T Get<T>()
        {
            return _container.Get<T>();
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}