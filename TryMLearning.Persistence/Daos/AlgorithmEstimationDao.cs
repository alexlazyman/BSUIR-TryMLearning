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
    public class AlgorithmEstimationDao : IAlgorithmEstimationDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmEstimationDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            var algorithmEstimationDbEntity = await _dbContext.AlgorithmEstimations
                .Include(a => a.Algorithm)
                .Include(a => a.Algorithm.AlgorithmParameters)
                .Include(a => a.DataSet)
                .Include(a => a.AlgorithmEstimator)
                .Include(a => a.AlgorithmParameterValues)
                .FirstOrDefaultAsync(a => a.AlgorithmEstimationId == algorithmEstimationId);

            var algorithmEstimation = Mapper.Map<AlgorithmEstimation>(algorithmEstimationDbEntity);

            return algorithmEstimation;
        }

        public async Task<AlgorithmEstimation> UpdateAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            var algorithmEstimationDbEntity = Mapper.Map<AlgorithmEstimationDbEntity>(algorithmEstimation);

            _dbContext.SafeUpdate(algorithmEstimationDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmEstimation = Mapper.Map<AlgorithmEstimation>(algorithmEstimationDbEntity);

            return algorithmEstimation;
        }

        public async Task<AlgorithmEstimation> InsertAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            var algorithmEstimationDbEntity = Mapper.Map<AlgorithmEstimationDbEntity>(algorithmEstimation);

            _dbContext.AlgorithmEstimations.Add(algorithmEstimationDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmEstimation = Mapper.Map<AlgorithmEstimation>(algorithmEstimationDbEntity);

            return algorithmEstimation;
        }

        public async Task QueueAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation)
        {
            var queue = await StorageUtils.GetQueue(StorageNames.TryMLearning, StorageQueueNames.ClassificationAlgorithm);

            var message = new CloudQueueMessage(algorithmEstimation.AlgorithmEstimationId.ToString());

            await queue.AddMessageAsync(message);
        }
    }
}