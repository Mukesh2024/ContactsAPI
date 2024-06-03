using ContactsApi.Models;
using ContactsApi.Repository;
using ContactsApi.UserService;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApi.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService.UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService.UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetUsersAsync_ReturnsUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "test", LastName = "user", Email = "test.user@example.com" },
                new User { Id = 2, FirstName = "unit", LastName = "test", Email = "unit.test@example.com" }
            };
            _userRepositoryMock.Setup(repo => repo.GetUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetUsersAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("test", result.First().FirstName);
        }

        [Fact]
        public async Task AddUserAsync_AddsUser()
        {
            // Arrange
            var user = new User { FirstName = "test", LastName = "user", Email = "test.user@example.com" };

            // Act
            await _userService.AddUserAsync(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task EditUserAsync_EditsUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "test", LastName = "user", Email = "test.user@example.com" };

            // Act
            await _userService.EditUserAsync(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.EditUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_DeletesUser()
        {
            // Arrange
            var userId = 1;

            // Act
            await _userService.DeleteUserAsync(userId);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
        }
    }
}
