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
    public class ClassificationDataSetSmapleDao : IDataSetSampleDao<ClassificationDataSetSmaple>
    {
        private readonly TryMLearningDbContext _dbContext;

        public ClassificationDataSetSmapleDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassificationDataSetSmaple>> AddDataSetSamplesAsync(List<ClassificationDataSetSmaple> dataSetSamples)
        {
            var dbEntities = dataSetSamples.Select(Mapper.Map<ClassificationDataSetSmapleDbEntity>).ToList();

            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbEntities.ForEach(e => _dbContext.ClassificationDataSmaples.Add(e));
            _dbContext.Configuration.AutoDetectChangesEnabled = true;

            await _dbContext.SaveChangesAsync();

            dataSetSamples = dbEntities.Select(Mapper.Map<ClassificationDataSetSmaple>).ToList();

            return dataSetSamples;
        }

        public async Task<int> GetDataSetSampleCountAsync(int dataSetId)
        {
            var count = await _dbContext.ClassificationDataSmaples
                .Where(s => s.DataSetId == dataSetId)
                .CountAsync();

            return count;
        }

        public async Task<ClassificationDataSetSmaple> GetDataSetSampleAsync(int dataSetSampleId)
        {
            var dbEntity = await _dbContext.ClassificationDataSmaples
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ClassificationDataSetSmapleId == dataSetSampleId);

            var dataSetSample = Mapper.Map<ClassificationDataSetSmaple>(dbEntity);

            return dataSetSample;
        }

        public async Task<List<ClassificationDataSetSmaple>> GetDataSetSamplesAsync(int dataSetId, int start, int count)
        {
            var dbEntities = await _dbContext.ClassificationDataSmaples
                .Where(s => s.DataSetId == dataSetId)
                .OrderBy(s => s.ClassificationDataSetSmapleId)
                .Skip(start)
                .Take(count)
                .ToListAsync();

            foreach (var dbEntity in dbEntities)
            {
                var doubleTuple = dbEntity.DoubleTuple;
                while (doubleTuple?.RelatedDoubleTupleId != null)
                {
                    await _dbContext.Entry(doubleTuple).Reference(t => t.RelatedDoubleTuple).LoadAsync();

                    doubleTuple = doubleTuple.RelatedDoubleTuple;
                }
            }

            var dataSetSamples = dbEntities.Select(Mapper.Map<ClassificationDataSetSmaple>).ToList();

            return dataSetSamples;
        }

        public async Task DeleteDataSetSamplesAsync(List<ClassificationDataSetSmaple> dataSetSamples)
        {
            var dbEntities = Mapper.Map<List<ClassificationDataSetSmapleDbEntity>>(dataSetSamples);

            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbEntities.ForEach(e => _dbContext.SafeDelete(e));
            _dbContext.Configuration.AutoDetectChangesEnabled = true;

            await _dbContext.SaveChangesAsync();
        }
    }
}