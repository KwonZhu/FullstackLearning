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
        List<User> Users = new List<User>()
        {
            new User {Id = 1, UserName = "John", Email = "John@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0987654321" },
            new User { Id = 2, UserName = "Mike", Email = "Mike@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0876543219" },
            new User { Id = 3, UserName = "Tom", Email = "Tom@gmail.com", Address = "brisbane", Gender=GenderEnum.Male, Password = "123", Phone = "0765432189"  },
        };

        #region Get
        [HttpGet("{id}")]
        //http://localhost:5289/api/user/GetUserInfoById/1
        public JsonResult GetUserInfoById(int id)
        {
            var _user = Users.FirstOrDefault(u => u.Id == id);
            return new JsonResult(_user == null ? "Not found" : _user);
        }

        //query string parameters don't need [HttpGet]
        //http://localhost:5289/api/user/GetUserInfoByEmail/?email=John@gmail.com
        public JsonResult GetUserInfoByEmail(string email)
        {
            var _user = Users.FirstOrDefault(u => u.Email == email);
            return new JsonResult(_user == null ? "Not found" : _user);

        }
        #endregion

        #region Post
        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromBody
        //{
        //    "Id" : "4", 
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
                var _user = Users.FirstOrDefault(u => u.Id == user.Id);
                if (_user == null)
                {
                    Users.Add(user);
                    return new JsonResult(user);
                }
                return new JsonResult("User id has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }

        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromForm
        public JsonResult AddUserFromForm([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                var _user = Users.FirstOrDefault(u => u.Id == user.Id);
                if (_user == null)
                {
                    Users.Add(user);
                    return new JsonResult(user);
                }
                return new JsonResult("User id has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        #region
        [HttpPut]
        public JsonResult UpdateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var _user = Users.FirstOrDefault(u => u.Id == user.Id);
                if (_user == null)
                {
                    return new JsonResult("User not found");


                }
                //user = updatedUser: Replaces the reference, causing the original object in the list to remain unchanged
               _user.UserName = user.UserName;
               _user.Email = user.Email;
               _user.Address = user.Address;
               _user.Gender = user.Gender;
               _user.Password = user.Password;
               _user.Phone = user.Phone; ;
                return new JsonResult(user);
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        //[HttpDelete("{id}")]
    }
}
