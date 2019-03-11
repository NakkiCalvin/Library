using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Responses;
using BLL.Entities;

namespace API.Requests
{
    public class LoginModel
    {
        public LoginModel() { }
        public string Email { get; set; }
        public string Pass { get; set; }

        public static explicit operator ResponseUserModel(LoginModel model)
        {
            return new ResponseUserModel
            {
                Email = model.Email
            };
        }

        public static explicit operator User(LoginModel userModel)
        {
            return new User
            {
                Email = userModel.Email,
            };
        }
    }
}
