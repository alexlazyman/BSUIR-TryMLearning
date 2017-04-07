using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmSessionService
    {
        Task<AlgorithmSession> GetAlgorithmSessionAsync(int algorithmSessionId);

        Task<AlgorithmSession> AddAlgorithmSessionAsync(AlgorithmSession algorithmSession);
    }
}