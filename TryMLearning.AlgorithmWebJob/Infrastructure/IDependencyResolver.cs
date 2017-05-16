using System;

namespace TryMLearning.AlgorithmWebJob.Infrastructure
{
    public interface IDependencyResolver
    {
        IDependencyScope BeginScope();
    }
}