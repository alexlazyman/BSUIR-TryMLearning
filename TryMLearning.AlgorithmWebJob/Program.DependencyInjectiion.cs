using Ninject;
using TryMLearning.AlgorithmWebJob.Infrastructure;


namespace TryMLearning.AlgorithmWebJob
{
    public partial class Program
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IDependencyResolver>().To<DependencyResolver>().InSingletonScope();

            return kernel;
        }
    }
}
