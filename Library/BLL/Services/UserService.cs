using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DataAccess;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Http;
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

        public Task<IdentityResult> CreateUser(User user, string password)
        {
            return  _manager.CreateAsync(user, password);
        }

        public Task<IdentityResult> AddToRole(User user, string role)
        {
            return _manager.AddToRoleAsync(user, role);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _manager.FindByNameAsync(email);
        }

        public Task<IList<string>> GetUserRoles(User user)
        {
            return _manager.GetRolesAsync(user);
        }

       
    }
}
