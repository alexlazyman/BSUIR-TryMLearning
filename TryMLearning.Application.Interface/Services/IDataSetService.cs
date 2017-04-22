using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IDataSetService
    {
        Task<DataSet> AddDataSetAsync(DataSet dataSet);

        Task<List<DataSet>> GetAllDataSetsAsync();

        Task<DataSet> GetDataSetAsync(int dataSetId);

        Task<DataSet> UpdateDataSetAsync(DataSet dataSet);

        Task DeleteDataSetAsync(int dataSetId);
    }
}