using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IEstimationService
    {
        Task<List<Estimation>> GetAllEstimationsAsync();

        Task<Estimation> GetEstimationAsync(int estimationId);

        Task DeleteEstimationAsync(int estimationId);

        Task<Estimation> RunEstimationAsync(Estimation estimation);

        Task ExecuteClassifierEstimationAsync(int estimationId);

        Task<List<EstimateResult>> GetClassifierEstimationResultAsync(int estimationId, List<EstimateRequest> estimateRequests);
    }
}