using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;
using TestWebApp.Controllers;

namespace Tests.UnitTests.WebAppTests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task CreateAsync_NullView_BadRequest()
        {
            var factory = new UserControllerFactory();

            var controller = factory.CreateUserController();

            var result = await controller.CreateAsync(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(((BadRequestObjectResult)result).Value, typeof(ViewModel.User.Create));
        }

        private class UserControllerFactory
        {
            public UserControllerFactory()
            {
                UserService = new Mock<IUserService> { };
            }

            public Mock<IUserService> UserService { get; private set; }

            internal TestUserController CreateUserController()
            {

                return new TestUserController(UserService.Object);
            }

            internal class TestUserController : UserController
            {
                public TestUserController(IUserService userService)
                    : base(userService)
                {
                }
            }
        }
    }
}
