using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.Validation;
using TryMLearning.Model;
using TryMLearning.Model.Exceptions;
using TryMLearning.Model.Validation;
using TryMLearning.Persistence.Interface;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly ITransactionScope _transactionScope;

        private readonly IAlgorithmDao _algorithmDao;
        private readonly IAlgorithmParameterDao _algorithmParameterDao;

        private readonly IValidator<Algorithm> _algorithmValidator;

        public AlgorithmService(
            ITransactionScope transactionScope,
            IAlgorithmDao algorithmDao,
            IAlgorithmParameterDao algorithmParameterDao,
            IValidator<Algorithm> algorithmValidator)
        {
            _transactionScope = transactionScope;
            _algorithmDao = algorithmDao;
            _algorithmParameterDao = algorithmParameterDao;
            _algorithmValidator = algorithmValidator;
        }

        public async Task<Algorithm> AddAlgorithmAsync(Algorithm algorithm)
        {
            var validationResult = await _algorithmValidator.ValidateAsync(algorithm);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Algorithm is not valid", validationResult.Errors);
            }

            Algorithm addedAlgorithm = null;

            using (var ts = _transactionScope.Begin())
            {
                try
                {
                    algorithm.AlgorithmId = 0;
                    addedAlgorithm = await _algorithmDao.InsertAlgorithmAsync(algorithm);

                    addedAlgorithm.Parameters = new List<AlgorithmParameter>();
                    foreach (var algParam in algorithm.Parameters)
                    {
                        algParam.AlgorithmParameterId = 0;
                        algParam.AlgorithmId = addedAlgorithm.AlgorithmId;

                        var addedAlgParam = await _algorithmParameterDao.InsertAlgorithmParameterAsync(algParam);

                        addedAlgorithm.Parameters.Add(addedAlgParam);
                    }

                    ts.Commit();
                }
                catch
                {
                    ts.Rollback();
                    throw;
                }
            }

            return addedAlgorithm;
        }

        public async Task<List<Algorithm>> GetAllAlgorithmsAsync()
        {
            var algorithms = await _algorithmDao.GetAllAlgorithmsAsync();

            return algorithms;
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
                if (algParam.AlgorithmParameterId != 0 &&
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
                if (updatedAlgParams[i].AlgorithmParameterId == 0)
                {
                    updatedAlgParams[i] = await _algorithmParameterDao.InsertAlgorithmParameterAsync(updatedAlgParams[i]);
                }
                else
                {
                    updatedAlgParams[i] = await _algorithmParameterDao.UpdateAlgorithmParameterAsync(updatedAlgParams[i]);
                }
            }
        }
    }
}