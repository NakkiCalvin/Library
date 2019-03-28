using System;
using System.Threading.Tasks;
using API.Mapping;
using API.Requests;
using API.Responses;
using AutoMapper;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Account")]
    [EnableCors("Policy")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISignInManager  _signInManager;
        private readonly IUserManager _userManager;
        private readonly IRoleManager _roleManager;
        private readonly ITokenService _tokenService;

        public AccountController(
            IUserManager userManager,
            ISignInManager signInManager,
            IRoleManager roleManager,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("LogOut")]
        public async Task Logout()
        {
            await _signInManager.Logout();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            var mapUser = Mapper.Map<RegisterUserModel, User>(model);
            mapUser.Id = Guid.NewGuid();
            var ir = await _userManager.CreateUser(mapUser, model.Password);
            var rere = await _userManager.AddToRole(mapUser, "User");
            return Ok(mapUser);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<object> GenerateToken(LoginModel authorize)
        {
            var configuredToken = new
            {
                access_token = _tokenService.GetEncodedJwtToken(authorize.Email),
                userEmail = authorize.Email,
            };

            return configuredToken;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<RoleModel> Create(RoleModel roleModel)
        {
            roleModel.Id = Guid.NewGuid();

            await _roleManager.AddRole((Role)roleModel);

            return roleModel;
        }
    }
}
