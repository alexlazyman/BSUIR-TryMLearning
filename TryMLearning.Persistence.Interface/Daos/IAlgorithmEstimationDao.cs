using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmEstimationDao
    {
        Task<List<AlgorithmEstimation>> GetAllAlgorithmEstimationsAsync(int userId);

        Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId);

        Task<AlgorithmEstimation> UpdateAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task<AlgorithmEstimation> InsertAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task QueueAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);
    }
}