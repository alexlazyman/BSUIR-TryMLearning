using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Helpers;
using TryMLearning.Persistence.Interface.Daos;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Daos
{
    public class UserDao : IUserDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public UserDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            var userDbEntity = Mapper.Map<UserDbEntity>(user);

            _dbContext.Users.Add(userDbEntity);
            await _dbContext.SaveChangesAsync();

            user = Mapper.Map<User>(userDbEntity);

            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userDbEntity = Mapper.Map<UserDbEntity>(user);

            _dbContext.SafeUpdate(userDbEntity);
            await _dbContext.SaveChangesAsync();

            user = Mapper.Map<User>(userDbEntity);

            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            var userDbEntity = Mapper.Map<UserDbEntity>(user);

            _dbContext.SafeDelete(userDbEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var userDbEntity = await _dbContext.Users
                .FirstOrDefaultAsync(a => a.UserId == userId);

            var user = Mapper.Map<User>(userDbEntity);

            return user;
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            var userDbEntity = await _dbContext.Users
                .FirstOrDefaultAsync(a => a.UserName == userName);

            var user = Mapper.Map<User>(userDbEntity);

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var userDbEntity = await _dbContext.Users
                .FirstOrDefaultAsync(a => a.Email == email);

            var user = Mapper.Map<User>(userDbEntity);

            return user;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}