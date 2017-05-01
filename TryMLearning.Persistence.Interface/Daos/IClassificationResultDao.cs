using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IClassificationResultDao
    {
        Task<List<ClassificationResult>> AddClassificationResultsAsync(List<ClassificationResult> classificationResults);
    }
}