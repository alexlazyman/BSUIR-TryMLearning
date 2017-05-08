using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmParameterDao
    {
        Task<AlgorithmParameter> InsertAlgorithmParameterAsync(AlgorithmParameter algorithmParameter);

        Task<AlgorithmParameter> UpdateAlgorithmParameterAsync(AlgorithmParameter algorithmParameter);

        Task DeleteAlgorithmParameterAsync(AlgorithmParameter algorithmParameter);
    }
}