using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmEstimateDao
    {
        Task<AlgorithmEstimate> GetAlgorithmEstimateAsync(int algorithmEstimateId);

        Task<AlgorithmEstimate> AddAlgorithmEstimateAsync(AlgorithmEstimate algorithmEstimate);
    }
}