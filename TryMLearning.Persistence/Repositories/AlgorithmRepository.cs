using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Repositories;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Repositories
{
    public class AlgorithmRepository : IAlgorithmRepository
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmRepository(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Algorithm> GetAsync(int id)
        {
            var algorithmDbEntity = await _dbContext.Algorithms
                .Include(a => a.Parameters)
                .FirstOrDefaultAsync(a => a.AlgorithmId == id);

            var algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public async Task<Algorithm> AddAsync(Algorithm entity)
        {
            var algorithmDbEntity = Mapper.Map<AlgorithmDbEntity>(entity);

            _dbContext.Algorithms.Add(algorithmDbEntity);
            await _dbContext.SaveChangesAsync();

            var algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public Task<Algorithm> UpdateAsync(Algorithm entity)
        {
            throw new System.NotImplementedException();
        }
    }
}