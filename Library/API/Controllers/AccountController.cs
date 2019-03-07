using System;
using System.Threading.Tasks;
using API.Requests;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISignInManager  _signInManager;
        private readonly IUserManager _userManager;

        public AccountController(
            IUserManager userManager,
            ISignInManager signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[HttpPost]
        //public async Task<object> Login([FromBody] LoginDto model)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        //    if (result.Succeeded)
        //    {
        //        var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
        //        return await GenerateJwtToken(model.Email, appUser);
        //    }

        //    throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        //}

        [HttpGet]
        [Route("Hello")]
        public Task<string> Hello()
        {
            return Task.FromResult("Hello");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = (User) model;
            newUser.Id = Guid.NewGuid();

            await _userManager.CreateUser(newUser, model.Password);
            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            return Ok(newUser);

            //throw new ApplicationException("UNKNOWN_ERROR");
        }
    }
}
