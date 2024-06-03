using ContactsApi.Controllers;
using ContactsApi.Models;
using ContactsApi.UserService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactsApi.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResultWithUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "Test", LastName = "user", Email = "test.uesr@example.com" },
                new User { Id = 2, FirstName = "Unit", LastName = "test", Email = "unit.test@example.com" }
            };
            _userServiceMock.Setup(service => service.GetUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _userController.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(2, returnUsers.Count);
        }

        [Fact]
        public async Task AddUser_ReturnsOkResult()
        {
            // Arrange
            var user = new User { FirstName = "test", LastName = "user", Email = "test.user@example.com" };

            // Act
            var result = await _userController.AddUser(user);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _userServiceMock.Verify(service => service.AddUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task EditUser_ReturnsOkResult()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "test", LastName = "user", Email = "test.user@example.com" };

            // Act
            var result = await _userController.EditUser(user.Id, user);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _userServiceMock.Verify(service => service.EditUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_ReturnsOkResult()
        {
            // Arrange
            var userId = 1;

            // Act
            var result = await _userController.DeleteUser(userId);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _userServiceMock.Verify(service => service.DeleteUserAsync(userId), Times.Once);
        }
    }
}


