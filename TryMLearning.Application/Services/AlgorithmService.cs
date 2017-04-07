using System;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmDao _algorithmDao;
        private readonly IAlgorithmSessionService _algorithmSessionService;

        public AlgorithmService(
            IAlgorithmDao algorithmDao,
            IAlgorithmSessionService algorithmSessionService)
        {
            _algorithmDao = algorithmDao;
            _algorithmSessionService = algorithmSessionService;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            algorithm = await _algorithmDao.AddAlgorithmAsync(algorithm);

            return algorithm;
        }

        public async Task<Algorithm> GetAlgorithmAsync(int algorithmId)
        {
            var algorithm = await _algorithmDao.GetAlgorithmAsync(algorithmId);

            return algorithm;
        }

        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            algorithm = await _algorithmDao.UpdateAlgorithmAsync(algorithm);

            return algorithm;
        }

        public async Task<AlgorithmSession> RunAlgorithmAsync(AlgorithmForm algorithmForm)
        {
            // TODO: Validate form.

            var algorithSession = new AlgorithmSession()
            {
                AlgorithmId = algorithmForm.AlgorithmId,
                Parameters = algorithmForm.Parameters.Select(p => new AlgorithmParameterValue()
                {
                    AlgorithmParameterId = p.AlgorithmParameterId,
                    Value = p.Value
                }).ToList()
            };

            algorithSession = await _algorithmSessionService.AddAlgorithmSessionAsync(algorithSession);

            await _algorithmDao.AddAlgorithmToRunQueue(algorithSession);

            return algorithSession;
        }
    }
}