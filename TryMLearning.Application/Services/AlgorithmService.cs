using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Validation;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmDao _algorithmDao;
        private readonly IAlgorithmParameterDao _algorithmParameterDao;
        private readonly IAlgorithmSessionService _algorithmSessionService;
        private readonly ITransactionScope _transactionScope;
        private readonly IValidator<Algorithm> _algorithmValidator;
        private readonly IValidator<AlgorithmForm> _algorithmFormValidator;

        public AlgorithmService(
            IAlgorithmDao algorithmDao,
            IAlgorithmParameterDao algorithmParameterDao,
            IAlgorithmSessionService algorithmSessionService,
            ITransactionScope transactionScope,
            IValidator<Algorithm> algorithmValidator,
            IValidator<AlgorithmForm> algorithmFormValidator)
        {
            _algorithmDao = algorithmDao;
            _algorithmParameterDao = algorithmParameterDao;
            _algorithmSessionService = algorithmSessionService;
            _transactionScope = transactionScope;
            _algorithmValidator = algorithmValidator;
            _algorithmFormValidator = algorithmFormValidator;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }

            //TODO: Check relationships and if issue exists throw AccessExcetion

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
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }

            //TODO: Check relationships and if issue exists throw AccessExcetion

            var existingAlgorithm = await _algorithmDao.GetAlgorithmAsync(algorithm.AlgorithmId);

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    await _algorithmDao.UpdateAlgorithmAsync(algorithm);
                    await UpdateAlgorithmParametersAsync(existingAlgorithm.Parameters, algorithm.Parameters, existingAlgorithm.AlgorithmId);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithm;
        }

        public async Task DeleteAlgorithmAsync(int algorithmId)
        {
            var algorithm = new Algorithm() { AlgorithmId = algorithmId };

            await _algorithmDao.DeleteAlgorithmAsync(algorithm);
        }

        public async Task<AlgorithmSession> RunAlgorithmAsync(AlgorithmForm algorithmForm)
        {
            var validationResult = await _algorithmFormValidator.ValidateAsync(algorithmForm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

            var algorithSession = new AlgorithmSession()
            {
                AlgorithmId = algorithmForm.AlgorithmId,
                ParameterValues = algorithmForm.Parameters.Select(p => new AlgorithmParameterValue()
                {
                    AlgorithmParameterId = p.AlgorithmParameterId,
                    Value = p.Value
                }).ToList()
            };

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithSession = await _algorithmSessionService.AddAlgorithmSessionAsync(algorithSession);
                    await _algorithmDao.AddAlgorithmToRunQueue(algorithSession);

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return algorithSession;
        }

        private async Task UpdateAlgorithmParametersAsync(List<AlgorithmParameter> existingAlgParams, List<AlgorithmParameter> updatedAlgParams, int algorithmId)
        {
            existingAlgParams = existingAlgParams ?? new List<AlgorithmParameter>();
            updatedAlgParams = updatedAlgParams ?? new List<AlgorithmParameter>();

            for (var i = 0; i < existingAlgParams.Count; i++)
            {
                if (updatedAlgParams.All(p => p.AlgorithmParameterId != existingAlgParams[i].AlgorithmParameterId))
                {
                    await _algorithmParameterDao.DeleteAlgorithmParameterAsync(existingAlgParams[i]);
                }
            }

            for (var i = 0; i < updatedAlgParams.Count; i++)
            {
                if (updatedAlgParams[i].AlgorithmParameterId <= 0)
                {
                    updatedAlgParams[i].AlgorithmId = algorithmId;
                    updatedAlgParams[i] = await _algorithmParameterDao.AddAlgorithmParameterAsync(updatedAlgParams[i]);
                }
                else
                {
                    updatedAlgParams[i] = await _algorithmParameterDao.UpdateAlgorithmParameterAsync(updatedAlgParams[i]);
                }
            }
        }
    }
}