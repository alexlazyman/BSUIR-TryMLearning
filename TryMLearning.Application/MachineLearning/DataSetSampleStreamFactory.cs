using Microsoft.Practices.Unity;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;

namespace TryMLearning.Application.MachineLearning
{
    public class DataSetSampleStreamFactory : IDataSetSampleStreamFactory
    {
        private readonly IUnityContainer _container;

        public DataSetSampleStreamFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IDataSetSampleStream<T> GetDataSetSampleStream<T>(int dataSetId)
        {
            return _container.Resolve<IDataSetSampleStream<T>>(new ParameterOverride("dataSetId", dataSetId));
        }
    }
}