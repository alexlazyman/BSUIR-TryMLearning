using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class UserService : IUserService, IUserStore<User>, IUserPasswordStore<User, string>, IUserEmailStore<User>
    {
        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public async Task CreateAsync(User user)
        {
            await _userDao.InsertUserAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userDao.UpdateUserAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userDao.DeleteUserAsync(user);
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            int userIdInt;
            if (!int.TryParse(userId, out userIdInt))
            {
                return null;
            }

            return await _userDao.GetUserAsync(userIdInt);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _userDao.GetUserByNameAsync(userName);
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
        }

        public async Task<string> GetPasswordHashAsync(User user)
        {
            return user.PasswordHash;
        }

        public async Task<bool> HasPasswordAsync(User user)
        {
            return true;
        }

        public async Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
        }

        public async Task<string> GetEmailAsync(User user)
        {
            return user.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(User user)
        {
            return true;
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userDao.GetUserByEmailAsync(email);
        }

        public void Dispose()
        {
        }
    }
}