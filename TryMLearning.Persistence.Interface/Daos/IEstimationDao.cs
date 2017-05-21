using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IEstimationDao
    {
        Task<List<Estimation>> GetAllEstimationsAsync(int userId);

        Task<Estimation> GetEstimationAsync(int estimationId);

        Task<Estimation> GetCompletedEstimationAsync(int algorithmId, int dataSetId);

        Task<Estimation> UpdateEstimationAsync(Estimation estimation);

        Task<Estimation> InsertEstimationAsync(Estimation estimation);

        Task DeleteEstimationAsync(Estimation estimation);

        Task QueueEstimationAsync(Estimation estimation);
    }
}