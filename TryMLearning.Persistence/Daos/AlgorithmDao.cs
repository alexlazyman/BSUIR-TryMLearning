using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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
    public class AlgorithmDao : IAlgorithmDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Algorithm>> GetAllAlgorithmsAsync()
        {
            var algorithmDbEntity = await _dbContext.Algorithms
                .Include(a => a.Author)
                .Include(a => a.AlgorithmParameters)
                .ToListAsync();

            var algorithms = algorithmDbEntity.Select(Mapper.Map<Algorithm>).ToList();

            return algorithms;
        }

        public async Task<Algorithm> GetAlgorithmAsync(int id)
        {
            var algorithmDbEntity = await _dbContext.Algorithms
                .Include(a => a.Author)
                .Include(a => a.AlgorithmParameters)
                .FirstOrDefaultAsync(a => a.AlgorithmId == id);

            var algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public async Task<Algorithm> InsertAlgorithmAsync(Algorithm algorithm)
        {
            var algorithmDbEntity = Mapper.Map<AlgorithmDbEntity>(algorithm);

            _dbContext.Algorithms.Add(algorithmDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            var algorithmDbEntity = Mapper.Map<AlgorithmDbEntity>(algorithm);

            _dbContext.SafeUpdate(algorithmDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithm = Mapper.Map<Algorithm>(algorithmDbEntity);

            return algorithm;
        }

        public async Task DeleteAlgorithmAsync(Algorithm algorithm)
        {
            var algorithmDbEntity = Mapper.Map<AlgorithmDbEntity>(algorithm);

            _dbContext.SafeDelete(algorithmDbEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}