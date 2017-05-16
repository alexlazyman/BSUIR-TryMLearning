using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using TryMLearning.AlgorithmWebJob.Contexts;
using TryMLearning.AlgorithmWebJob.Infrastructure;
using TryMLearning.Application.Interface.Contexts;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Contexts;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.MachineLearning;
using TryMLearning.Application.MachineLearning.Classifiers;
using TryMLearning.Application.MachineLearning.Contexts;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.FalseNegativeError;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.FalsePositiveError;
using TryMLearning.Application.MachineLearning.Estimates.Classifier.GeneralizationAbility;
using TryMLearning.Application.MachineLearning.Estimators;
using TryMLearning.Application.Services;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Model.MachineLearning.Estimators;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;
using TryMLearning.Persistence;
using TryMLearning.Persistence.Daos;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

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
