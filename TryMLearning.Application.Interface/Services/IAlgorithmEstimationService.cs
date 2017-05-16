using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmEstimationService
    {
        Task<List<AlgorithmEstimation>> GetAllAlgorithmEstimationsAsync();

        Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId);

        Task<AlgorithmEstimation> RunEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task ExecuteClassifierEstimationAsync(int algorithmEstimationId);

        Task<List<EstimateResponse>> GetClassifierEstimationResultAsync(int algorithmEstimationId, List<EstimateRequest> estimateRequests);
    }
}