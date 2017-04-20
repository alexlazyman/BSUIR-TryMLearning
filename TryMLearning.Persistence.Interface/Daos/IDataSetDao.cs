using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IDataSetDao
    {
        Task<DataSet> AddDataSetAsync(DataSet dataSet);

        Task<DataSet> GetDataSetAsync(int dataSetId);

        Task<DataSet> UpdateDataSetAsync(DataSet dataSet);

        Task DeleteDataSetAsync(DataSet dataSet);
    }
}