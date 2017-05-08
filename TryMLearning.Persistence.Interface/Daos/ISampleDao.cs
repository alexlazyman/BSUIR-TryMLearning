using System.Collections.Generic;
using System.Threading.Tasks;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface ISampleDao<T>
    {
        Task<List<T>> AddSamplesAsync(List<T> samples);

        Task<int> GetSampleCountAsync(int dataSetId);

        Task<T> GetSampleAsync(int sampleId);

        Task<List<T>> GetSamplesAsync(int dataSetId, int start, int count);

        Task<List<T>> GetAllSamplesAsync(int dataSetId);

        Task DeleteSamplesAsync(List<T> samples);
    }
}