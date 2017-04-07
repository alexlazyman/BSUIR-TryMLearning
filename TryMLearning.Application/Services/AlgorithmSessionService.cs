using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmSessionService : IAlgorithmSessionService
    {
        private readonly IAlgorithmSessionDao _algorithmSessionDao;

        public AlgorithmSessionService(IAlgorithmSessionDao algorithmSessionDao)
        {
            _algorithmSessionDao = algorithmSessionDao;
        }

        public async Task<AlgorithmSession> GetAlgorithmSessionAsync(int algorithmSessionId)
        {
            return await _algorithmSessionDao.GetAlgorithmSessionAsync(algorithmSessionId);
        }

        public async Task<AlgorithmSession> AddAlgorithmSessionAsync(AlgorithmSession algorithmSession)
        {
            return await _algorithmSessionDao.AddAlgorithmSessionAsync(algorithmSession);
        }
    }
}