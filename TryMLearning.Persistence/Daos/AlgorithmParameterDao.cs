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
    public class AlgorithmParameterDao : IAlgorithmParameterDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public AlgorithmParameterDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AlgorithmParameter> AddAlgorithmParameterAsync(AlgorithmParameter algorithmParameter)
        {
            var algorithmParameterDbEntity = Mapper.Map<AlgorithmParameterDbEntity>(algorithmParameter);

            _dbContext.AlgorithmParameters.Add(algorithmParameterDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmParameter = Mapper.Map<AlgorithmParameter>(algorithmParameterDbEntity);

            return algorithmParameter;
        }

        public async Task<AlgorithmParameter> UpdateAlgorithmParameterAsync(AlgorithmParameter algorithmParameter)
        {
            var algorithmParameterDbEntity = Mapper.Map<AlgorithmParameterDbEntity>(algorithmParameter);

            _dbContext.SafeUpdate(algorithmParameterDbEntity);
            await _dbContext.SaveChangesAsync();

            algorithmParameter = Mapper.Map<AlgorithmParameter>(algorithmParameterDbEntity);

            return algorithmParameter;
        }

        public async Task DeleteAlgorithmParameterAsync(AlgorithmParameter algorithmParameter)
        {
            var algorithmParameterDbEntity = Mapper.Map<AlgorithmParameterDbEntity>(algorithmParameter);

            _dbContext.SafeDelete(algorithmParameterDbEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}