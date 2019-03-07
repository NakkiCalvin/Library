using System;
using System.Threading.Tasks;
using API.Controllers;
using API.Requests;
using API.Responses;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace APITests
{
    public class UnitTest1
    {
        static Mock<IUserManager> mockedManager = new Mock<IUserManager>();
        static Mock<ISignInManager> mockedSignInManager = new Mock<ISignInManager>();
        AccountController controller = new AccountController(mockedManager.Object, mockedSignInManager.Object);

        [Fact]
        public async Task CheckCreate()
        {
            var user = new User
            {
                Email = "aaaa@gmail.com",
            };

            mockedManager.Setup(p => p.CreateUser(user, "Qqqqqqqq12_")).Returns(Task.FromResult(new IdentityResult()));

            
            var model = new RegisterUserModel {Email = user.Email, Password = "Qqqqqqqq12_" };

            var result = await controller.Register(model);

            Assert.NotNull(result);
            mockedManager.Verify(x => x.CreateUser(It.IsAny<User>(), It.Is<string>(pass => pass == "Qqqqqqqq12_")), Times.Once);
        }
    }
}
