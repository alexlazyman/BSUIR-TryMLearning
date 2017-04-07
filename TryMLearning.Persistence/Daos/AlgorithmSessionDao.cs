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
    public class AlgorithmSessionDao : IAlgorithmSessionDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmSessionDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AlgorithmSession> GetAlgorithmSessionAsync(int algorithmSessionId)
        {
            var algorithmSessionDbEntity = await _dbContext.AlgorithmSessions
                .Include(a => a.Parameters)
                .FirstOrDefaultAsync(a => a.AlgorithmSessionId == algorithmSessionId);

            var algorithmSession = Mapper.Map<AlgorithmSession>(algorithmSessionDbEntity);

            return algorithmSession;
        }

        public async Task<AlgorithmSession> AddAlgorithmSessionAsync(AlgorithmSession algorithmSession)
        {
            var algorithmSessionDbEntity = Mapper.Map<AlgorithmSessionDbEntity>(algorithmSession);

            _dbContext.AlgorithmSessions.Add(algorithmSessionDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmSession = Mapper.Map<AlgorithmSession>(algorithmSessionDbEntity);

            return algorithmSession;
        }
    }
}