using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DataAccess;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class UserService : IUserManager
    {
        private readonly UserManager<User> _manager;

        public UserService(UserManager<User> manager)
        {
            _manager = manager;
        }

        public async Task<IdentityResult> CreateUser(User user, string password)
        {
            return await _manager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddToRole(User user, string role)
        {
            return await _manager.AddToRoleAsync(user, role);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _manager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _manager.GetRolesAsync(user);
        }
    }
}
