using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IClassificationResultService
    {
        Task<List<ClassificationResult>> AddClassificationResultsAsync(int algorithmEstimateId, List<ClassificationResult> classificationResults);
    }
}