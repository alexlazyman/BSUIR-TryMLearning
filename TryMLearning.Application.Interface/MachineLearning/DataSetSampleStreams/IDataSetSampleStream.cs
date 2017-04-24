using System.Collections.Generic;
using System.Threading.Tasks;

namespace TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams
{
    public interface IDataSetSampleStream<T>
    {
        Task<int> LengthAsync { get; }

        Task<IEnumerable<T>> ReadAllAsync();
    }
}