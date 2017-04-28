using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmDao
    {
        Task<List<Algorithm>> GetAllAlgorithmsAsync();

        Task<Algorithm> GetAlgorithmAsync(int algorithmId);

        Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm);

        Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm);

        Task DeleteAlgorithmAsync(Algorithm algorithm);

        Task AddAlgorithmToRunQueue(AlgorithmEstimate algorithmEstimate);
    }
}