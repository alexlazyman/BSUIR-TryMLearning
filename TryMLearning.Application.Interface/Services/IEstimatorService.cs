using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IEstimatorService
    {
        Task<List<Estimator>> GetAllEstimatorsAsync();

    }
}