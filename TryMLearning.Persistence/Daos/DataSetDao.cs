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
    public class DataSetDao : IDataSetDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public DataSetDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataSet> AddDataSetAsync(DataSet dataSet)
        {
            var dbEntity = Mapper.Map<DataSetDbEntity>(dataSet);

            _dbContext.DataSets.Add(dbEntity);
            await _dbContext.SaveChangesAsync();

            dataSet = Mapper.Map<DataSet>(dbEntity);

            return dataSet;
        }

        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            var dbEntities = await _dbContext.DataSets.ToListAsync();

            var dataSets = dbEntities.Select(Mapper.Map<DataSet>).ToList();

            return dataSets;
        }

        public async Task<DataSet> GetDataSetAsync(int dataSetId)
        {
            var dbEntity = await _dbContext.DataSets.FindAsync(dataSetId);

            var dataSet = Mapper.Map<DataSet>(dbEntity);

            return dataSet;
        }

        public async Task<DataSet> UpdateDataSetAsync(DataSet dataSet)
        {
            var dbEntity = Mapper.Map<DataSetDbEntity>(dataSet);

            _dbContext.SafeUpdate(dbEntity);
            await _dbContext.SaveChangesAsync();

            dataSet = Mapper.Map<DataSet>(dbEntity);

            return dataSet;
        }

        public async Task DeleteDataSetAsync(DataSet dataSet)
        {
            var dbEntity = Mapper.Map<DataSetDbEntity>(dataSet);

            _dbContext.SafeDelete(dbEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}