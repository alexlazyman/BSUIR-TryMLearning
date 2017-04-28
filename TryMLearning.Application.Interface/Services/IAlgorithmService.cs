using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmService
    {
        Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm);

        Task<List<Algorithm>> GetAllAlgorithmsAsync();

        Task<Algorithm> GetAlgorithmAsync(int algorithmId);

        Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm);

        Task DeleteAlgorithmAsync(int algorithmId);

        Task<AlgorithmEstimate> RunAlgorithmAsync(int algorithmId, int dataSetId, List<AlgorithmParameterValue> parameterValues);

        Task EstimateClassificationAlgorithmAsync(int algorithmEstimateId);
    }
}