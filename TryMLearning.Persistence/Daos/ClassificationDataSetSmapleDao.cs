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
    public class ClassificationDataSetSmapleDao : IClassificationDataSetSmapleDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public ClassificationDataSetSmapleDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassificationDataSetSmaple>> AddClassificationDataSetSmaplesAsync(List<ClassificationDataSetSmaple> classificationDataSetSmaples)
        {
            var dbEntities = classificationDataSetSmaples.Select(Mapper.Map<ClassificationDataSetSmapleDbEntity>).ToList();

            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbEntities.ForEach(e => _dbContext.ClassificationDataSmaples.Add(e));
            _dbContext.Configuration.AutoDetectChangesEnabled = true;

            await _dbContext.SaveChangesAsync();

            classificationDataSetSmaples = dbEntities.Select(Mapper.Map<ClassificationDataSetSmaple>).ToList();

            return classificationDataSetSmaples;
        }

        public async Task<int> GetClassificationDataSetSmapleCountAsync(int dataSetId)
        {
            var count = await _dbContext.ClassificationDataSmaples
                .Where(s => s.DataSetId == dataSetId)
                .CountAsync();

            return count;
        }

        public async Task<List<ClassificationDataSetSmaple>> GetClassificationDataSetSmaplesAsync(int dataSetId, int start, int count)
        {
            var dbEntities = await _dbContext.ClassificationDataSmaples
                .Where(s => s.DataSetId == dataSetId)
                .OrderBy(s => s.ClassificationDataSetSmapleId)
                .Skip(start)
                .Take(count)
                .ToListAsync();

            var classificationDataSmaples = dbEntities.Select(Mapper.Map<ClassificationDataSetSmaple>).ToList();

            return classificationDataSmaples;
        }

        public async Task DeleteClassificationDataSetSmapleAsync(ClassificationDataSetSmaple classificationDataSetSmaple)
        {
            var dbEntity = Mapper.Map<ClassificationDataSetSmapleDbEntity>(classificationDataSetSmaple);

            _dbContext.SafeDelete(dbEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}