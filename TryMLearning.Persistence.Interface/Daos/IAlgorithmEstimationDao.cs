using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmEstimationDao
    {
        Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId);

        Task<AlgorithmEstimation> InsertAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task QueueAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);
    }
}