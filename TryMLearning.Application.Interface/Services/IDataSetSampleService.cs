using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IDataSetSampleService<T>
    {
        Task<List<T>> AddDataSetSamplesAsync(List<T> dataSetSamples);

        Task<int> GetDataSetSampleCountAsync(int dataSetId);

        Task<List<T>> GetDataSetSamplesAsync(int dataSetId, int start, int count);

        Task DeleteDataSetSampleAsync(int dataSetSampleId);

        Task DeleteDataSetSamplesAsync(params int[] dataSetSampleIds);

        Task DeleteDataSetSamplesAsync(int dataSetId);
    }
}