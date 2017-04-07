using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmSessionDao
    {
        Task<AlgorithmSession> GetAlgorithmSessionAsync(int algorithmSessionId);

        Task<AlgorithmSession> AddAlgorithmSessionAsync(AlgorithmSession algorithmSession);
    }
}