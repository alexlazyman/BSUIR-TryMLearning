using System;

namespace TryMLearning.AlgorithmWebJob.Infrastructure
{
    public interface IDependencyScope : IDisposable
    {
        T Get<T>();
    }
}