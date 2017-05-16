using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class EstimatorService : IEstimatorService
    {
        private readonly IEstimatorDao _estimatorDao;

        public EstimatorService(
            IEstimatorDao estimatorDao)
        {
            _estimatorDao = estimatorDao;
        }

        public async Task<List<Estimator>> GetAllEstimatorsAsync()
        {
            return await _estimatorDao.GetAllEstimatorsAsync();
        }
    }
}