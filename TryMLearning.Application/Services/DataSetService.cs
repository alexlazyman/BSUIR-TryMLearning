using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.Application.Services
{
    public class DataSetService : IDataSetService
    {
        public Task<DataSet> AddDataSetAsync(DataSet dataSet)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetDataSetAsync(int dataSetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> UpdateDataSetAsync(DataSet dataSet)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteDataSetAsync(int dataSetId)
        {
            throw new System.NotImplementedException();
        }
    }
}