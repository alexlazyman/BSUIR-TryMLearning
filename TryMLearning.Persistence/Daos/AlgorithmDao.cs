using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Persistence.Constants;
using TryMLearning.Persistence.Helpers;
using TryMLearning.Persistence.Interface.Daos;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Daos
{
    public class AlgorithmDao : IAlgorithmDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Algorithm> GetAlgorithmAsync(int id)
        {
            var algorithmDbEntity = await _dbContext.Algorithms
                .Include(a => a.Parameters)
                .FirstOrDefaultAsync(a => a.AlgorithmId == id);

            var algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            var algorithmDbEntity = Mapper.Map<AlgorithmDbEntity>(algorithm);

            _dbContext.Algorithms.Add(algorithmDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAlgorithmToRunQueue(AlgorithmSession algorithmSession)
        {
            var queue = await StorageUtils.GetQueue(StorageNames.TryMLearning, StorageQueueNames.Algorithm);

            var message = new CloudQueueMessage(algorithmSession.AlgorithmSessionId.ToString());

            await queue.AddMessageAsync(message);
        }
    }
}