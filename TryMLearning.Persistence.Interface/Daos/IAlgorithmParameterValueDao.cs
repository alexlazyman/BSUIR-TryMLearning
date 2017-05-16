using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IAlgorithmParameterValueDao
    {
        Task<AlgorithmParameterValue> InsertAlgorithmParameterValueAsync(AlgorithmParameterValue algorithmParameterValue);
    }
}