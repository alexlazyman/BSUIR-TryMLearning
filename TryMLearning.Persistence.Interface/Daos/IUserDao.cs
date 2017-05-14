using System;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IUserDao : IDisposable
    {
        Task<User> InsertUserAsync(User user);

        Task<User> UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);

        Task<User> GetUserAsync(int userId);

        Task<User> GetUserByNameAsync(string userName);

        Task<User> GetUserByEmailAsync(string email);
    }
}