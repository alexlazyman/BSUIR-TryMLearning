using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class ClassificationSampleService : ISampleService<ClassificationSample>
    {
        private string DataSetNotFoundErrorMessage(int dataSetId) => $"Data set with id {dataSetId} does not exist";
        private string SampleNotFoundErrorMessage(int sampleId) => $"Classification data set sample with id {sampleId} does not exist";
        private string NotClassificationDataSetErrorMessage(DataSet dataSet) => $"Data set with id {dataSet.DataSetId} does not belong to classification data sets";
        private string NotAcceptableSampleErrorMessage(int dataSetId, int sampleId) => $"Data set sample with id {sampleId} does not belong to data set with id {dataSetId}";

        private readonly ISampleDao<ClassificationSample> _classificationDataSetSampleDao;
        private readonly IDataSetDao _dataSetDao;

        public ClassificationSampleService(
            ISampleDao<ClassificationSample> classificationDataSetSampleDao,
            IDataSetDao dataSetDao)
        {
            _classificationDataSetSampleDao = classificationDataSetSampleDao;
            _dataSetDao = dataSetDao;
        }

        public async Task<List<ClassificationSample>> AddSamplesAsync(int dataSetId, List<ClassificationSample> samples)
        {
            var dataSet = await _dataSetDao.GetDataSetAsync(dataSetId);
            if (dataSet == null)
            {
                throw new NotFoundException(DataSetNotFoundErrorMessage(dataSetId));
            }

            if (dataSet.Type != DataSetType.Classification)
            {
                throw new UnauthorizedAccessException(NotClassificationDataSetErrorMessage(dataSet));
            }

            samples.ForEach(s => s.DataSetId = dataSetId);

            var addedSamples = await _classificationDataSetSampleDao.AddSamplesAsync(samples);

            return addedSamples;
        }

        public async Task<int> GetSampleCountAsync(int dataSetId)
        {
            var dataSet = await _dataSetDao.GetDataSetAsync(dataSetId);
            if (dataSet == null)
            {
                throw new NotFoundException(DataSetNotFoundErrorMessage(dataSetId));
            }

            if (dataSet.Type != DataSetType.Classification)
            {
                throw new UnauthorizedAccessException(NotClassificationDataSetErrorMessage(dataSet));
            }

            var count = await _classificationDataSetSampleDao.GetSampleCountAsync(dataSetId);

            return count;
        }

        public async Task<List<ClassificationSample>> GetSamplesAsync(int dataSetId, int start, int count)
        {
            var dataSet = await _dataSetDao.GetDataSetAsync(dataSetId);
            if (dataSet == null)
            {
                throw new NotFoundException(DataSetNotFoundErrorMessage(dataSetId));
            }

            if (dataSet.Type != DataSetType.Classification)
            {
                throw new UnauthorizedAccessException(NotClassificationDataSetErrorMessage(dataSet));
            }

            var samples = await _classificationDataSetSampleDao.GetSamplesAsync(dataSetId, start, count);

            return samples;
        }

        public async Task DeleteSamplesAsync(int dataSetId, List<int> sampleIds)
        {
            var dataSet = await _dataSetDao.GetDataSetAsync(dataSetId);
            if (dataSet == null)
            {
                throw new NotFoundException(DataSetNotFoundErrorMessage(dataSetId));
            }

            if (dataSet.Type != DataSetType.Classification)
            {
                throw new UnauthorizedAccessException(NotClassificationDataSetErrorMessage(dataSet));
            }

            foreach (var sampleId in sampleIds)
            {
                var sample = await _classificationDataSetSampleDao.GetSampleAsync(sampleId);
                if (sample == null)
                {
                    throw new NotFoundException(SampleNotFoundErrorMessage(sampleId));
                }

                if (sample.DataSetId != dataSetId)
                {
                    throw new UnauthorizedAccessException(NotAcceptableSampleErrorMessage(dataSetId, sampleId));
                }
            }

            var samples = sampleIds.Select(id => new ClassificationSample
            {
                ClassificationDataSetSampleId = id
            }).ToList();

            await _classificationDataSetSampleDao.DeleteSamplesAsync(samples);
        }
    }
}