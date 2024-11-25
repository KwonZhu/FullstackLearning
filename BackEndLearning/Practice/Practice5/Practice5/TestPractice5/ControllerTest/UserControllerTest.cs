using Moq;
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
    }
}
