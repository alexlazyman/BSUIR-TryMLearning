using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using TryMLearning.Model;
using TryMLearning.Persistence.Constants;
using TryMLearning.Persistence.Helpers;
using TryMLearning.Persistence.Interface.Daos;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Daos
{
    public class AlgorithmEstimateDao : IAlgorithmEstimateDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmEstimateDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AlgorithmEstimate> GetAlgorithmEstimateAsync(int algorithmEstimateId)
        {
            var algorithmEstimateDbEntity = await _dbContext.AlgorithmEstimates
                .Include(a => a.Algorithm)
                .Include(a => a.Algorithm.AlgorithmParameters)
                .Include(a => a.DataSet)
                .Include(a => a.Test)
                .Include(a => a.AlgorithmParameterValues)
                .FirstOrDefaultAsync(a => a.AlgorithmEstimateId == algorithmEstimateId);

            var algorithmEstimate = Mapper.Map<AlgorithmEstimate>(algorithmEstimateDbEntity);

            return algorithmEstimate;
        }

        public async Task<AlgorithmEstimate> AddAlgorithmEstimateAsync(AlgorithmEstimate algorithmEstimate)
        {
            var algorithmEstimateDbEntity = Mapper.Map<AlgorithmEstimateDbEntity>(algorithmEstimate);

            _dbContext.AlgorithmEstimates.Add(algorithmEstimateDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmEstimate = Mapper.Map<AlgorithmEstimate>(algorithmEstimateDbEntity);

            return algorithmEstimate;
        }
    }
}