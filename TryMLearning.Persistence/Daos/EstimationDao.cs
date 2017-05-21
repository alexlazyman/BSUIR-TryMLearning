using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    public class EstimationDao : IEstimationDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public EstimationDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Estimation>> GetAllEstimationsAsync(int userId)
        {
            var estimationDbEntity = await _dbContext.Estimations
                .Include(a => a.User)
                .Include(a => a.Algorithm)
                .Include(a => a.Algorithm.AlgorithmParameters)
                .Include(a => a.AlgorithmParameterValues)
                .Include(a => a.DataSet)
                .Where(a => a.UserId == userId)
                .ToListAsync();

            var estimations = estimationDbEntity.Select(Mapper.Map<Estimation>).ToList();

            return estimations;
        }

        public async Task<Estimation> GetEstimationAsync(int estimationId)
        {
            var estimationDbEntity = await _dbContext.Estimations
                .Include(a => a.User)
                .Include(a => a.Algorithm)
                .Include(a => a.Algorithm.AlgorithmParameters)
                .Include(a => a.AlgorithmParameterValues)
                .Include(a => a.DataSet)
                .FirstOrDefaultAsync(a => a.EstimationId == estimationId);

            var estimation = Mapper.Map<Estimation>(estimationDbEntity);

            return estimation;
        }

        public async Task<Estimation> GetCompletedEstimationAsync(int algorithmId, int dataSetId)
        {
            var estimationDbEntity = await _dbContext.Estimations
                .Include(a => a.User)
                .Include(a => a.Algorithm)
                .Include(a => a.Algorithm.AlgorithmParameters)
                .Include(a => a.AlgorithmParameterValues)
                .Include(a => a.DataSet)
                .FirstOrDefaultAsync(e =>
                    e.AlgorithmId == algorithmId
                    && e.DataSetId == dataSetId
                    && e.Status == EstimationStatus.Completed);

            var estimation = Mapper.Map<Estimation>(estimationDbEntity);

            return estimation;
        }

        public async Task<Estimation> UpdateEstimationAsync(Estimation estimation)
        {
            var estimationDbEntity = Mapper.Map<EstimationDbEntity>(estimation);

            _dbContext.SafeUpdate(estimationDbEntity);
            await _dbContext.SaveChangesAsync();

            estimation = Mapper.Map<Estimation>(estimationDbEntity);

            return estimation;
        }

        public async Task<Estimation> InsertEstimationAsync(Estimation estimation)
        {
            var estimationDbEntity = Mapper.Map<EstimationDbEntity>(estimation);

            _dbContext.Estimations.Add(estimationDbEntity);
            await _dbContext.SaveChangesAsync();

            estimation = Mapper.Map<Estimation>(estimationDbEntity);

            return estimation;
        }

        public async Task DeleteEstimationAsync(Estimation estimation)
        {
            _dbContext.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[Estimation] WHERE EstimationId = {estimation.EstimationId}");

            await _dbContext.SaveChangesAsync();
        }

        public async Task QueueEstimationAsync(Estimation estimation)
        {
            var queue = await StorageUtils.GetQueue(StorageNames.TryMLearning, StorageQueueNames.ClassificationAlgorithm);

            var message = new CloudQueueMessage(estimation.EstimationId.ToString());

            await queue.AddMessageAsync(message);
        }
    }
}