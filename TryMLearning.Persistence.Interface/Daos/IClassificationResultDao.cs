using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IClassificationResultDao
    {
        Task<List<ClassificationResult>> InsertClassificationResultsAsync(List<ClassificationResult> classificationResults);

        Task<List<ClassificationResult>> GetClassificationResultsAsync(int algorithmEstimationId);
    }
}