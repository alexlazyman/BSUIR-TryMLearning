using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface ISampleService<T>
    {
        Task<List<T>> AddSamplesAsync(int dataSetId, List<T> dataSetSamples);

        Task<int> GetSampleCountAsync(int dataSetId);

        Task<List<T>> GetSamplesAsync(int dataSetId, int start, int count);

        Task DeleteSamplesAsync(int dataSetId, List<int> dataSetSampleIds);
    }
}