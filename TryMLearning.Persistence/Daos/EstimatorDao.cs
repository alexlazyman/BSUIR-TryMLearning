using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Persistence.Daos
{
    public class EstimatorDao : IEstimatorDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public EstimatorDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Estimator>> GetAllEstimatorsAsync()
        {
            var estimatorDbEntities = await _dbContext.Estimators
                .ToListAsync();

            var estimator = estimatorDbEntities.Select(Mapper.Map<Estimator>).ToList();

            return estimator;
        }
    }
}