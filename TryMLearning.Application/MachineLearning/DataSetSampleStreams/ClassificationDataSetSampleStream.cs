using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.DataSetSampleStreams
{
    public class ClassificationDataSetSampleStream : IDataSetSampleStream<ClassificationDataSetSmaple>
    {
        private readonly int _dataSetId;

        private readonly IDataSetSampleService<ClassificationDataSetSmaple> _classificationDataSetSmapleService;

        public ClassificationDataSetSampleStream(
            int dataSetId,
            IDataSetSampleService<ClassificationDataSetSmaple> classificationDataSetSmapleService)
        {
            _dataSetId = dataSetId;
            _classificationDataSetSmapleService = classificationDataSetSmapleService;
        }

        public Task<int> LengthAsync => _classificationDataSetSmapleService.GetDataSetSampleCountAsync(_dataSetId);

        public async Task<IEnumerable<ClassificationDataSetSmaple>> ReadAllAsync()
        {
            var length = await LengthAsync;

            return await _classificationDataSetSmapleService.GetDataSetSamplesAsync(_dataSetId, 0, length);
        }
    }
}