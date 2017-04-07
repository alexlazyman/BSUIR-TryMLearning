using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Repositories;

namespace TryMLearning.Application.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmRepository _algorithmRepository;

        public AlgorithmService(IAlgorithmRepository algorithmRepository)
        {
            _algorithmRepository = algorithmRepository;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            algorithm = await _algorithmRepository.AddAsync(algorithm);

            return algorithm;
        }

        public async Task<Algorithm> GetAlgorithmAsync(int algorithmId)
        {
            var algorithm = await _algorithmRepository.GetAsync(algorithmId);

            return algorithm;
        }

        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            algorithm = await _algorithmRepository.UpdateAsync(algorithm);

            return algorithm;
        }
    }
}