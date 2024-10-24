using Microsoft.AspNetCore.Mvc;
using Practice3.Models;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace Practice3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        //http://localhost:5289/api/user/GetUserInfoById/1
        public JsonResult GetUserInfoById(int id)
        {
            var _user = Users.FirstOrDefault(u => u.UserId == id);
            return new JsonResult(_user == null ? "User not found" : _user);
        }

        //GetUserInfoByEmail
        //query string parameters don't need [HttpGet]
        //http://localhost:5289/api/user/GetUserInfoByEmail/?email=John@gmail.com
        public JsonResult GetUserInfoByEmail(string email)
        {
            var _user = Users.FirstOrDefault(u => u.Email == email);
            return new JsonResult(_user == null ? "User not found" : _user);

        }
        #endregion

        #region Post
        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromBody
        //{
        //    "UserId" : "4", 
        //    "UserName" : "lily", 
        //    "Email" : "lily@gmail.com", 
        //    "Address" : "brisbane", 
        //    "Gender" : 0, 
        //    "Password" : "123", 
        //    "Phone" : "0987654321"
        //}
        public JsonResult AddUserFromBody([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var _user = Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (_user == null)
                {
                    Users.Add(user);
                    return new JsonResult(user);
                }
                return new JsonResult("UserId has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }

        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromForm
        public JsonResult AddUserFromForm([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                var _user = Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (_user == null)
                {
                    Users.Add(user);
                    return new JsonResult(user);
                }
                return new JsonResult("UserId has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        #region Put
        [HttpPut]
        public JsonResult UpdateUserFromBody([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var _userIndex = Users.FindIndex(u => u.UserId == user.UserId);
                if (_userIndex == -1)
                {
                    return new JsonResult("User not found");
                }
                Users[_userIndex] = user;
                return new JsonResult(user);
            }
            return new JsonResult("ModelState.IsValid false");
        }

        [HttpPut]
        public JsonResult UpdateUserFromForm([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                var _userIndex = Users.FindIndex(u => u.UserId == user.UserId);
                if (_userIndex == -1)
                {
                    return new JsonResult("User not found");
                }
                Users[_userIndex] = user;
                return new JsonResult(user);
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        #region Delete
        //DeleteUserByEmail
        public JsonResult DeleteUserByEmail(string email)
        {
            var _user = Users.FirstOrDefault(u => u.Email == email);
            if (_user == null)
            {
                return new JsonResult("User not found");
            }
            Users.Remove(_user);
            return new JsonResult(_user);
        }
        #endregion
    }
}
