using System.Collections.Generic;
using System.Threading.Tasks;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IDataSetSampleDao<T>
    {
        Task<List<T>> AddDataSetSamplesAsync(List<T> dataSetSamples);

        Task<int> GetDataSetSampleCountAsync(int dataSetId);

        Task<T> GetDataSetSampleAsync(int dataSetSampleId);

        Task<List<T>> GetDataSetSamplesAsync(int dataSetId, int start, int count);

        Task DeleteDataSetSamplesAsync(List<T> dataSetSamples);
    }
}