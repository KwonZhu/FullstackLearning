using Microsoft.AspNetCore.Mvc;
using Practice4.Filters;
using Practice4.Models;
using Practice4.ViewModels;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomActionFilter]
    public class UserController : ControllerBase
    {
        //static list: the data will persist between requests
        public static List<User> Users = new List<User>()
        {
            new User {UserId = 1, UserName = "John", Email = "John@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0987654321" },
            new User { UserId = 2, UserName = "Mike", Email = "Mike@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0876543219" },
            new User { UserId = 3, UserName = "Tom", Email = "Tom@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0765432189"  },
        };

        #region Get
        [HttpGet("{id}")]
        //http://localhost:5252/api/user/GetUserInfoById/1
        public CommonResult<User> GetUserInfoById(int id)
        {
            var _user = Users.FirstOrDefault(u => u.UserId == id);
            if (_user == null)
            {
                return new CommonResult<User>() { Success = false, Message = "Failed", Error = "User not found" };
            }
            return new CommonResult<User>() { Success = true, Message = "Success", Data = _user };
        }

        //GetUserInfoByEmail
        //query string parameters don't need [HttpGet]
        //http://localhost:5252/api/user/GetUserInfoByEmail/?email=John@gmail.com
        public CommonResult<User> GetUserInfoByEmail(string email)
        {
            var _user = Users.FirstOrDefault(u => u.Email == email);
            if (_user == null)
            {
                return new CommonResult<User>() { Success = false, Message = "Failed", Error = "User not found" };
            }
            return new CommonResult<User>() { Success = true, Message = "Success", Data = _user };

        }
        #endregion

        #region Post
        [HttpPost]
        //http://localhost:5252//api/user/AddUserFromBody
        //{
        //    "UserId" : "4", 
        //    "UserName" : "lily", 
        //    "Email" : "lily@gmail.com", 
        //    "Address" : "brisbane", 
        //    "Gender" : 0, 
        //    "Password" : "123", 
        //    "Phone" : "0987654321"
        //}
        public CommonResult<User> AddUserFromBody([FromBody] User user)
        {
            return AddUser(user);
        }

        [HttpPost]
        //http://localhost:5252/api/user/AddUserFromForm
        public CommonResult<User> AddUserFromForm([FromForm] User user)
        {
            return AddUser(user);
        }
        #endregion

        #region Put
        [HttpPut]
        //http://localhost:5252/api/user/UpdateUserFromBody
        public CommonResult<User> UpdateUserFromBody([FromBody] User user)
        {
            return UpdateUser(user);
        }

        [HttpPut]
        //http://localhost:5252/api/user/UpdateUserFromForm
        public CommonResult<User> UpdateUserFromForm([FromForm] User user)
        {
            return UpdateUser(user);
        }
        #endregion

        #region Delete
        //DeleteUserByEmail
        //http://localhost:5252/api/user/DeleteUserByEmail?email=Mike@gmail.com
        public CommonResult<User> DeleteUserByEmail(string email)
        {
            var _user = Users.FirstOrDefault(u => u.Email == email);
            if (_user == null)
            {
                return new CommonResult<User>() { Success = false, Message = "Failed", Error = "User not found" };
            }
            Users.Remove(_user);
            return new CommonResult<User>() { Success = true, Message = "Success", Data = _user };
        }
        #endregion

        #region Helper Method
        private CommonResult<User> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                var _user = Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (_user == null)
                {
                    Users.Add(user);
                    return new CommonResult<User>() { Success = true, Message = "Success", Data = user };
                }
                return new CommonResult<User>() { Success = false, Message = "Failed", Error = "UserId has been taken" };
            }
            StringBuilder errors = new StringBuilder();
            foreach (var key in ModelState.Keys)
            {
                errors.Append(key + ":");
                foreach (var error in ModelState[key].Errors)
                {
                    errors.Append(error.ErrorMessage + " ");
                }
                errors.AppendLine();
            }
            return new CommonResult<User>() { Success = false, Message = "Failed", Error = errors.ToString() };
        }

        private CommonResult<User> UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var _userIndex = Users.FindIndex(u => u.UserId == user.UserId);
                if (_userIndex == -1)
                {
                    return new CommonResult<User>() { Success = false, Message = "Failed", Error = "User not found" };
                }
                Users[_userIndex] = user;
                return new CommonResult<User>() { Success = true, Message = "Success", Data = user };
            }
            StringBuilder errors = new StringBuilder();
            foreach (var key in ModelState.Keys)
            {
                errors.Append(key + ":");
                foreach (var error in ModelState[key].Errors)
                {
                    errors.Append(error.ErrorMessage + " ");
                }
                errors.AppendLine();
            }
            return new CommonResult<User>() { Success = false, Message = "Failed", Error = errors.ToString() };
        }
        #endregion
    }
}
