using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class DataSetService : IDataSetService
    {
        private readonly IDataSetDao _dataSetDao;

        public DataSetService(
            IDataSetDao dataSetDao)
        {
            _dataSetDao = dataSetDao;
        }

        public async Task<DataSet> AddDataSetAsync(DataSet dataSet)
        {
            return await _dataSetDao.InsertDataSetAsync(dataSet);
        }

        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await _dataSetDao.GetAllDataSetsAsync();
        }

        public async Task<DataSet> GetDataSetAsync(int dataSetId)
        {
            return await _dataSetDao.GetDataSetAsync(dataSetId);
        }

        public async Task<DataSet> UpdateDataSetAsync(DataSet dataSet)
        {
            return await _dataSetDao.UpdateDataSetAsync(dataSet);
        }

        public async Task DeleteDataSetAsync(int dataSetId)
        {
            var dataSet = new DataSet
            {
                DataSetId = dataSetId
            };

            await _dataSetDao.DeleteDataSetAsync(dataSet);
        }
    }
}