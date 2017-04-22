using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IDataSetSampleService<T>
    {
        Task<List<T>> AddDataSetSamplesAsync(int dataSetId, List<T> dataSetSamples);

        Task<int> GetDataSetSampleCountAsync(int dataSetId);

        Task<List<T>> GetDataSetSamplesAsync(int dataSetId, int start, int count);

        Task DeleteDataSetSamplesAsync(int dataSetId, List<int> dataSetSampleIds);
    }
}