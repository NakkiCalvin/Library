using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using API.Requests;
using API.Responses;
using BLL.Entities;
using BLL.Managers;
using BLL.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace APITests.UserTests
{
    public class ControllerTests
    {
        private static Mock<IUserManager> _mockedManager = new Mock<IUserManager>();
        private static Mock<ISignInManager> _mockedSignInManager = new Mock<ISignInManager>();
        private static Mock<IRoleManager> _mockedRoleManager = new Mock<IRoleManager>();
        private static Mock<ITokenService> _mockedTokenManager = new Mock<ITokenService>();
        AccountController _controller = new AccountController(_mockedManager.Object, _mockedSignInManager.Object, _mockedRoleManager.Object, _mockedTokenManager.Object);

        [Fact]
        public async Task CheckCreateUser()
        {
            var user = new User
            {
                Email = "aaaa@gmail.com",
            };

            _mockedManager.Setup(p => p.CreateUser(user, "Qqqqqqqq12_")).Returns(Task.FromResult(new IdentityResult()));

            var model = new RegisterUserModel {Email = user.Email, Password = "Qqqqqqqq12_" };

            var result = await _controller.Register(model);

            Assert.NotNull(result);
            _mockedManager.Verify(x => x.CreateUser(It.IsAny<User>(), It.Is<string>(pass => pass == "Qqqqqqqq12_")), Times.Once);
        }

        [Fact]
        public async Task CheckAddToRole()
        {
            var user = new User
            {
                Email = "aaaa@gmail.com",
            };

            var model = new RegisterUserModel { Email = user.Email, Password = "Qqqqqqqq12_" };

            var result = await _controller.Register(model);

            _mockedManager.Verify(x => x.AddToRole(user, It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task CheckGetUserRoles()
        {
            var user = new User
            {
                Email = "aaaa@gmail.com",
            };

            var model = new RegisterUserModel { Email = user.Email, Password = "Qqqqqqqq12_" };
            var result = await _controller.Register(model);
            _mockedManager.Setup(x => x.AddToRole(user, It.IsAny<string>())).Returns(Task.FromResult(new IdentityResult()));
            _mockedManager.Setup(p => p.GetUserRoles(user)).Returns(Task.FromResult(It.IsAny<IList<string>>()));

            _mockedManager.Verify(x => x.GetUserRoles(user), Times.Once);
        }

        [Fact]
        public async Task CheckUserByEmail()
        {
            _mockedManager.Setup(x => x.GetUserByEmail("vova@gmail.com")).Returns(Task.FromResult(new User()));

            var logmodel = new LoginModel {Email = "vova@gmail.com", Pass = "fafafa1sfAAa_" };
            var res = await _controller.GenerateToken(logmodel);

            _mockedTokenManager.Verify(x => x.GetEncodedJwtToken(logmodel.Email), Times.Once);
            //_mockedManager.Setup(x => x.GetUserByEmail(user.Email)).Returns(Task.FromResult(new User()));

            //_mockedManager.Verify(x => x.GetUserByEmail(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Logout()
        {
            await _controller.Logout();
            _mockedSignInManager.Verify(x => x.Logout(), Times.Once);
        }

        [Fact]
        public async Task CheckRemoveRole()
        {
            //arrange
            Role role = new Role();
            role.Name = "User";

            _mockedRoleManager.Setup(p => p.RemoveRole(role)).Returns(Task.FromResult(new IdentityResult()));


            //act

            //await service.AddRole(role);
            //var result = await service.RemoveRole(role);

            //assert

            //Assert.Null(result);
        }

    }
}
