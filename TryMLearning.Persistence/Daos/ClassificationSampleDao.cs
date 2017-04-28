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
    public class ClassificationSampleDao : ISampleDao<ClassificationSample>
    {
        private readonly TryMLearningDbContext _dbContext;

        public ClassificationSampleDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassificationSample>> AddSamplesAsync(List<ClassificationSample> samples)
        {
            var dbEntities = samples.Select(Mapper.Map<ClassificationSampleDbEntity>).ToList();

            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbEntities.ForEach(e => _dbContext.ClassificationDataSamples.Add(e));
            _dbContext.Configuration.AutoDetectChangesEnabled = true;

            await _dbContext.SaveChangesAsync();

            samples = dbEntities.Select(Mapper.Map<ClassificationSample>).ToList();

            return samples;
        }

        public async Task<int> GetSampleCountAsync(int dataSetId)
        {
            var count = await _dbContext.ClassificationDataSamples
                .Where(s => s.DataSetId == dataSetId)
                .CountAsync();

            return count;
        }

        public async Task<ClassificationSample> GetSampleAsync(int sampleId)
        {
            var dbEntity = await _dbContext.ClassificationDataSamples
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ClassificationDataSetSampleId == sampleId);

            var sample = Mapper.Map<ClassificationSample>(dbEntity);

            return sample;
        }

        public async Task<List<ClassificationSample>> GetSamplesAsync(int dataSetId, int start, int count)
        {
            var dbEntities = await _dbContext.ClassificationDataSamples
                .AsNoTracking()
                .Include(s => s.FeatureTuples)
                .Where(s => s.DataSetId == dataSetId)
                .OrderBy(s => s.ClassificationDataSetSampleId)
                .Skip(start)
                .Take(count)
                .ToListAsync();

            var samples = dbEntities.Select(Mapper.Map<ClassificationSample>).ToList();

            return samples;
        }

        public async Task DeleteSamplesAsync(List<ClassificationSample> samples)
        {
            var dbEntities = Mapper.Map<List<ClassificationSampleDbEntity>>(samples);

            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbEntities.ForEach(e => _dbContext.SafeDelete(e));
            _dbContext.Configuration.AutoDetectChangesEnabled = true;

            await _dbContext.SaveChangesAsync();
        }
    }
}