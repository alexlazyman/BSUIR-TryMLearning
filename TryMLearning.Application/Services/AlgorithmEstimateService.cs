using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmEstimateService : IAlgorithmEstimateService
    {
        private readonly IAlgorithmEstimateDao _algorithmEstimateDao;

        public AlgorithmEstimateService(IAlgorithmEstimateDao algorithmEstimateDao)
        {
            _algorithmEstimateDao = algorithmEstimateDao;
        }

        public async Task<AlgorithmEstimate> GetAlgorithmEstimateAsync(int algorithmEstimateId)
        {
            return await _algorithmEstimateDao.GetAlgorithmEstimateAsync(algorithmEstimateId);
        }

        public async Task<AlgorithmEstimate> AddAlgorithmEstimateAsync(AlgorithmEstimate algorithmEstimate)
        {
            return await _algorithmEstimateDao.AddAlgorithmEstimateAsync(algorithmEstimate);
        }
    }
}