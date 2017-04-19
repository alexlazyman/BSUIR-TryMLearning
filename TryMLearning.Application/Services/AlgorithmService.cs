using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IValidator<AlgorithmSession> _algorithmSessionValidator;

        public AlgorithmService(
            IAlgorithmDao algorithmDao,
            IAlgorithmParameterDao algorithmParameterDao,
            IAlgorithmSessionService algorithmSessionService,
            ITransactionScope transactionScope,
            IValidator<Algorithm> algorithmValidator,
            IValidator<AlgorithmSession> algorithmSessionValidator)
        {
            _algorithmDao = algorithmDao;
            _algorithmParameterDao = algorithmParameterDao;
            _algorithmSessionService = algorithmSessionService;
            _transactionScope = transactionScope;
            _algorithmValidator = algorithmValidator;
            _algorithmSessionValidator = algorithmSessionValidator;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }

            // Clear Ids of entities
            algorithm.AlgorithmId = 0;
            foreach (var algorithmParameter in algorithm.Parameters)
            {
                algorithmParameter.AlgorithmId = 0;
                algorithmParameter.AlgorithmParameterId = 0;
            }

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
            
            var existingAlgorithm = await _algorithmDao.GetAlgorithmAsync(algorithm.AlgorithmId);
            if (existingAlgorithm == null)
            {
                throw new UnauthorizedAccessException("Algorithm does not exist");
            }

            foreach (var algParam in algorithm.Parameters)
            {
                algParam.AlgorithmId = algorithm.AlgorithmId;
                if (algParam.AlgorithmParameterId > 0 &&
                    existingAlgorithm.Parameters.All(p => p.AlgorithmParameterId != algParam.AlgorithmParameterId))
                {
                    algParam.AlgorithmParameterId = 0;
                }
            }

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    await _algorithmDao.UpdateAlgorithmAsync(algorithm);
                    await UpdateAlgorithmParametersAsync(existingAlgorithm.Parameters, algorithm.Parameters);

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

        public async Task<AlgorithmSession> RunAlgorithmAsync(int algorithmId, List<AlgorithmParameterValue> parameterValues)
        {
            var algorithSession = new AlgorithmSession()
            {
                AlgorithmId = algorithmId,
                ParameterValues = parameterValues
            };

            var validationResult = await _algorithmSessionValidator.ValidateAsync(algorithSession);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm form is not valid", validationResult.Errors);
            }

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

        private async Task UpdateAlgorithmParametersAsync(List<AlgorithmParameter> existingAlgParams, List<AlgorithmParameter> updatedAlgParams)
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