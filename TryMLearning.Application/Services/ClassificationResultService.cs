using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class ClassificationResultService : IClassificationResultService
    {
        private readonly IClassificationResultDao _classificationResultDao;

        public ClassificationResultService(
            IClassificationResultDao classificationResultDao)
        {
            _classificationResultDao = classificationResultDao;
        }

        public async Task<List<ClassificationResult>> AddClassificationResultsAsync(int algorithmEstimationId, List<ClassificationResult> classificationResults)
        {
            classificationResults.ForEach(r => r.AlgorithmEstimationId = algorithmEstimationId);

            return await _classificationResultDao.InsertClassificationResultsAsync(classificationResults);
        }

        public async Task<List<ClassificationResult>> GetClassificationResultsAsync(int algorithmEstimationId)
        {
            return await _classificationResultDao.GetClassificationResultsAsync(algorithmEstimationId);
        }
    }
}