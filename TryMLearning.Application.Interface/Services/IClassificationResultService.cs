using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IClassificationResultService
    {
        Task<List<ClassificationResult>> AddClassificationResultsAsync(int algorithmEstimationId, List<ClassificationResult> classificationResults);

        Task<List<ClassificationResult>> GetClassificationResultsAsync(int algorithmEstimationId);
    }
}