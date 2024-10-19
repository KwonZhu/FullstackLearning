using Microsoft.AspNetCore.Mvc;
using Practice3.Models;
using System.Net;
using System.Numerics;
using System.Reflection;

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
                return new JsonResult(null);
            }
            var _user = Users.FirstOrDefault(u => u.Id == user.id);
            if (!_user == null)
            {
                return new JsonResult("User id has been taken");
            }
            Users.Add(user);
            return new JsonResult(user);
        }

        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromForm
        public JsonResult AddUserFromForm([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(null);
            }
            var _user = Users.FirstOrDefault(u => u.Id == user.id);
            if (!_user == null)
            {
                return new JsonResult("User id has been taken");
            }
            Users.Add(user);
            return new JsonResult(user);
        }
        #endregion

        #region
        [HttpPut("{id}")]
        #endregion

        //[HttpDelete("{id}")]
    }
}
