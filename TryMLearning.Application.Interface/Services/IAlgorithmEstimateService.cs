using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmEstimateService
    {
        Task<AlgorithmEstimate> GetAlgorithmEstimateAsync(int algorithmEstimateId);

        Task<AlgorithmEstimate> AddAlgorithmEstimateAsync(AlgorithmEstimate algorithmEstimate);
    }
}