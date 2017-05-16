using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public Task<User> InsertUserAsync(User user)
        {
            return _userDao.InsertUserAsync(user);
        }

        public Task<User> UpdateUserAsync(User user)
        {
            return _userDao.UpdateUserAsync(user);
        }

        public Task DeleteUserAsync(User user)
        {
            return _userDao.DeleteUserAsync(user);
        }

        public Task<User> GetUserAsync(int userId)
        {
            return _userDao.GetUserAsync(userId);
        }

        public Task<User> GetUserByNameAsync(string userName)
        {
            return _userDao.GetUserByNameAsync(userName);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userDao.GetUserByEmailAsync(email);
        }
    }
}