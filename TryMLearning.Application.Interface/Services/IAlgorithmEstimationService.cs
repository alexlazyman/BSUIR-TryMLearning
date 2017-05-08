using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmEstimationService
    {
        Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId);

        Task<AlgorithmEstimation> AddAlgorithmEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task<AlgorithmEstimation> RunEstimationAsync(AlgorithmEstimation algorithmEstimation);

        Task ExecuteClassifierEstimationAsync(int algorithmEstimationId);

        Task<ClassifierEstimationResult> GetClassifierEstimationResultAsync(ClassifierEstimationResultRequest classifierEstimationResultRequest);
    }
}