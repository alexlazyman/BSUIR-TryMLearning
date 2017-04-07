using System.Threading.Tasks;

namespace TryMLearning.Persistence.Interface.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
