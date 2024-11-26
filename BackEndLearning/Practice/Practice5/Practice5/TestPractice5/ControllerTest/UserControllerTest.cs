using Moq;
using MySqlX.XDevAPI.Common;
using Practice5.Controllers;
using Practice5.Enum;
using Practice5.IServices;
using Practice5.Models;
using Practice5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace TestPractice5.ControllerTest
{
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _mockUserService;

        public UserControllerTest()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        [Fact]
        public void AddUser_Should_Return_ValidationError_When_ModelState_IsValid()
        {
            //Arrange
            _userController.ModelState.AddModelError("UserName", "User name can't be null");//string key, Exception exception
            var input = new AddUserInput()
            {
                Password = "123"
            };

            //Act
            var result = _userController.AddUser(input);

            //Assert
            Assert.IsType<CommonResult>(result);
            Assert.False(result.Success);
            Assert.Equal("Validaitons are failed", result.Message);
            Assert.Contains("User name can't be null", result.Errors);
        }

        [Fact]
        public void AddUser_Should_Return_Success_When_User_IsAdded()
        {
            // Arrange
            var input = new AddUserInput
            {
                UserName = "TestUser",
                Password = "123",
                Email = "test@example.com",
                Age = 25,
                Gender = Gender.Male,
                Address = "Test Address",
                Phone = "1234567890"
            };

            _mockUserService.Setup(service => service.AddUser(It.IsAny<User>())).Returns(true);

            //Act
            var result = _userController.AddUser(input);

            //Assert
            Assert.IsType<CommonResult>(result);
            Assert.True(result.Success);
            Assert.Empty(result.Errors);
            _mockUserService.Verify(service => service.AddUser(It.Is<User>(u => u.UserName == input.UserName)), Times.Once);
        }

        [Fact]
        public void GetUsers_Should_Return_List_Of_Users()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, UserName = "User1", Password = "123",Email = "user1@example.com" },
                new User { Id = 2, UserName = "User2", Password = "456",Email = "user2@example.com" }
            };

            _mockUserService.Setup(s => s.GetUsers()).Returns(users);

            // Act
            var result = _userController.GetUsers();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(users[0].UserName, result[0].UserName);
            Assert.Equal(users[1].Email, result[1].Email);
            _mockUserService.Verify(service => service.GetUsers(), Times.Once);
        }

        [Fact]
        public void UpdateUsers_Should_Return_ValidationError_When_ModelState_IsInvalid()
        {
            // Arrange
            _userController.ModelState.AddModelError("Email", "email format is not correct");
            var input = new UpdateUserInput
            {
                UserName = "TestUser",
                Password = "123",
                Email = "TestUser@"
            };

            // Act
            var result = _userController.UpdateUsers(input);

            // Assert
            Assert.IsType<CommonResult>(result);
            Assert.False(result.Success);
            Assert.Equal("Validaitons are failed", result.Message);
            Assert.Contains("email format is not correct", result.Errors);
        }

        [Fact]
        public void UpdateUsers_Should_Return_Success_When_User_IsUpdated()
        {
            // Arrange
            var input = new UpdateUserInput
            {
                Id = 1,
                UserName = "UpdatedUser",
                Password = "123",
                Email = "updated@example.com",
                Age = 30,
                Gender = Gender.Female,
                Address = "Updated Address",
                Phone = "9876543210"
            };

            _mockUserService.Setup(s => s.UpdateUsers(It.IsAny<User>())).Returns(true);

            // Act
            var result = _userController.UpdateUsers(input);

            // Assert
            Assert.IsType<CommonResult>(result);
            Assert.True(result.Success);
            Assert.Equal("User updated successfully", result.Message);
            Assert.Empty(result.Errors);
            _mockUserService.Verify(service => service.UpdateUsers(It.Is<User>(u => u.UserName == input.UserName)), Times.Once);
        }

        [Fact]
        public void DeleteUsers_Should_Return_BlooeanResult()
        {
            // Arrange
            var validId = 1;
            _mockUserService.Setup(s => s.DeleteUser(validId)).Returns(true);

            // Act
            var validResult = _userController.DeleteUsers(validId);

            // Assert
            Assert.IsType<CommonResult>(validResult);
            Assert.True(validResult.Success);
            Assert.Equal("User deleted successfully", validResult.Message);

            // Arrange
            var invalidId = 9999;
            _mockUserService.Setup(s => s.DeleteUser(invalidId)).Returns(false);

            // Act
            var invalidResult = _userController.DeleteUsers(invalidId);

            // Assert
            Assert.IsType<CommonResult>(invalidResult);
            Assert.False(invalidResult.Success);
            Assert.Equal("User not found or deletion failed", invalidResult.Message);
        }
    }
}
