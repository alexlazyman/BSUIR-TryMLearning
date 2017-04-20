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
    public class ClassificationDataSetSampleService : IDataSetSampleService<ClassificationDataSetSmaple>
    {
        private string DataSetNotFoundErrorMessage(int dataSetId) => $"Data set with id {dataSetId} does not exist";
        private string DataSetSampleNotFoundErrorMessage(int dataSetSampleId) => $"Classification data set sample with id {dataSetSampleId} does not exist";
        private string NotClassificationDataSetErrorMessage(DataSet dataSet) => $"Data set with id {dataSet.DataSetId} does not belong to classification data sets";
        private string NotAcceptableDataSetSampleErrorMessage(int dataSetId, int dataSetSampleId) => $"Data set sample with id {dataSetSampleId} does not belong to data set with id {dataSetId}";

        private readonly IDataSetSampleDao<ClassificationDataSetSmaple> _classificationDataSetSmapleDao;
        private readonly IDataSetDao _dataSetDao;

        public ClassificationDataSetSampleService(
            IDataSetSampleDao<ClassificationDataSetSmaple> classificationDataSetSmapleDao,
            IDataSetDao dataSetDao)
        {
            _classificationDataSetSmapleDao = classificationDataSetSmapleDao;
            _dataSetDao = dataSetDao;
        }

        public async Task<List<ClassificationDataSetSmaple>> AddDataSetSamplesAsync(int dataSetId, List<ClassificationDataSetSmaple> dataSetSamples)
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

            dataSetSamples.ForEach(s => s.DataSetId = dataSetId);

            var samples = await _classificationDataSetSmapleDao.AddDataSetSamplesAsync(dataSetSamples);

            return samples;
        }

        public async Task<int> GetDataSetSampleCountAsync(int dataSetId)
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

            var count = await _classificationDataSetSmapleDao.GetDataSetSampleCountAsync(dataSetId);

            return count;
        }

        public async Task<List<ClassificationDataSetSmaple>> GetDataSetSamplesAsync(int dataSetId, int start, int count)
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

            var samples = await _classificationDataSetSmapleDao.GetDataSetSamplesAsync(dataSetId, start, count);

            return samples;
        }

        public async Task DeleteDataSetSamplesAsync(int dataSetId, List<int> dataSetSampleIds)
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

            foreach (var dataSetSampleId in dataSetSampleIds)
            {
                var dataSetSample = await _classificationDataSetSmapleDao.GetDataSetSampleAsync(dataSetSampleId);
                if (dataSetSample == null)
                {
                    throw new NotFoundException(DataSetSampleNotFoundErrorMessage(dataSetSampleId));
                }

                if (dataSetSample.DataSetId != dataSetId)
                {
                    throw new UnauthorizedAccessException(NotAcceptableDataSetSampleErrorMessage(dataSetId, dataSetSampleId));
                }
            }

            var samples = dataSetSampleIds.Select(id => new ClassificationDataSetSmaple
            {
                ClassificationDataSetSmapleId = id
            }).ToList();

            await _classificationDataSetSmapleDao.DeleteDataSetSamplesAsync(samples);
        }
    }
}