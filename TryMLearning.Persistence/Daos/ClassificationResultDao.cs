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
    public class ClassificationResultDao : IClassificationResultDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public ClassificationResultDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassificationResult>> AddClassificationResultsAsync(List<ClassificationResult> classificationResults)
        {
            var dbEntities = classificationResults.Select(Mapper.Map<ClassificationResultDbEntity>).ToList();

            dbEntities.ForEach(e => _dbContext.ClassificationResults.Add(e));

            await _dbContext.SaveChangesAsync();

            classificationResults = dbEntities.Select(Mapper.Map<ClassificationResult>).ToList();

            return classificationResults;
        }

        public async Task<List<ClassificationResult>> GetClassificationResultsAsync(int algorithmEstimationId)
        {
            var dbEntities = await _dbContext.ClassificationResults
                .AsNoTracking()
                .Where(s => s.AlgorithmEstimationId == algorithmEstimationId)
                .ToListAsync();

            var classificationResults = dbEntities.Select(Mapper.Map<ClassificationResult>).ToList();

            return classificationResults;
        }
    }
}