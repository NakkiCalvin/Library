﻿using System;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapUser = Mapper.Map<RegisterUserModel, User>(model);
            mapUser.Id = Guid.NewGuid();
            await _userManager.CreateUser(mapUser, model.Password);
            await _userManager.AddToRole(mapUser, "User");
            return Ok(mapUser);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<object> GenerateToken(RegisterUserModel authorize)
        {

            User actualUser = await _userManager.GetUserByEmail(authorize.Email);
            if (actualUser == null)
            {
                return BadRequest("This user does not exists");
            }

            var result = await _signInManager.CheckPass(actualUser, authorize.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Wrong Password");
            }

            var configuredToken = new
            {
                access_token = _tokenService.GetEncodedJwtToken(authorize.Email),
                userEmail = actualUser.Email,
                id = actualUser.Id
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
