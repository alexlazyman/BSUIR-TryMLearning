﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmDao
    {
        Task<List<Algorithm>> GetAllAlgorithmsAsync();

        Task<Algorithm> GetAlgorithmAsync(int algorithmId);

        Task<Algorithm> InsertAlgorithmAsync(Algorithm algorithm);

        Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm);

        Task DeleteAlgorithmAsync(Algorithm algorithm);
    }
}