using System;
using System.Collections.Generic;
using System.Text;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class SignInService : ISignInManager
    {
        private readonly SignInManager<User> _manager;

        public SignInService(SignInManager<User> manager)
        {
            _manager = manager;
        }
    }
}
