using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;

namespace TryMLearning.Application.Interface.MachineLearning
{
    public interface IDataSetSampleStreamFactory
    {
        IDataSetSampleStream<T> GetDataSetSampleStream<T>(int dataSetId);
    }
}