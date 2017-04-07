using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IAlgorithmService
    {
        Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm);

        Task<Algorithm> GetAlgorithmAsync(int algorithmId);

        Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm);
    }
}