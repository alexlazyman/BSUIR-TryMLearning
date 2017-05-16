using System.Data.Entity;
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
    public class AlgorithmParameterValueDao : IAlgorithmParameterValueDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmParameterValueDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AlgorithmParameterValue> InsertAlgorithmParameterValueAsync(AlgorithmParameterValue algorithmParameterValue)
        {
            var algorithmParameterValueDbEntity = Mapper.Map<AlgorithmParameterValueDbEntity>(algorithmParameterValue);

            _dbContext.AlgorithmParameterValues.Add(algorithmParameterValueDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmParameterValue = Mapper.Map<AlgorithmParameterValue>(algorithmParameterValueDbEntity);

            return algorithmParameterValue;
        }
    }
}