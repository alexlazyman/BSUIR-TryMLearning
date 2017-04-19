using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class ClassificationDataSetSampleService : IDataSetSampleService<ClassificationDataSetSmaple>
    {
        private readonly IClassificationDataSetSmapleDao _classificationDataSetSmapleDao;
        private readonly ITransactionScope _transactionScope;

        public ClassificationDataSetSampleService(
            IClassificationDataSetSmapleDao classificationDataSetSmapleDao,
            ITransactionScope transactionScope)
        {
            _classificationDataSetSmapleDao = classificationDataSetSmapleDao;
            _transactionScope = transactionScope;
        }

        public async Task<List<ClassificationDataSetSmaple>> AddDataSetSamplesAsync(List<ClassificationDataSetSmaple> dataSetSamples)
        {
            var samples = await _classificationDataSetSmapleDao.AddClassificationDataSetSmaplesAsync(dataSetSamples);

            return samples;
        }

        public async Task<int> GetDataSetSampleCountAsync(int dataSetId)
        {
            var count = await _classificationDataSetSmapleDao.GetClassificationDataSetSmapleCountAsync(dataSetId);

            return count;
        }

        public async Task<List<ClassificationDataSetSmaple>> GetDataSetSamplesAsync(int dataSetId, int start, int count)
        {
            var samples = await _classificationDataSetSmapleDao.GetClassificationDataSetSmaplesAsync(dataSetId, start, count);

            return samples;
        }

        public async Task DeleteDataSetSampleAsync(int dataSetSampleId)
        {
            var sample = new ClassificationDataSetSmaple
            {
                ClassificationDataSetSmapleId = dataSetSampleId
            };

            await _classificationDataSetSmapleDao.DeleteClassificationDataSetSmapleAsync(sample);
        }

        public async Task DeleteDataSetSamplesAsync(params int[] dataSetSampleIds)
        {
            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    foreach (var dataSetSampleId in dataSetSampleIds)
                    {
                        await DeleteDataSetSampleAsync(dataSetSampleId);
                    }

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }
        }

        public Task DeleteDataSetSamplesAsync(int dataSetId)
        {
            throw new System.NotImplementedException();
        }
    }
}