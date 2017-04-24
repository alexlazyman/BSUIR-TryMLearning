using System.Threading.Tasks;
using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Classifiers
{
    public interface IClassifier
    {
        Task ComputeAsync(IDataSetSampleStream<ClassificationDataSetSmaple> stream);
    }
}