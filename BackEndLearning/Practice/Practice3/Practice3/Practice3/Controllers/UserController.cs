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
        #region Get
        [HttpGet("{id}")]
        //http://localhost:5289/api/user/GetUserInfoById/1
        public JsonResult GetUserInfoById(int id)
        {
            User _user = new User()
            { Id = id, UserName = "lily", Email = "lily@gmail.com", Address = "brisbane", Gender = GenderEnum.Female, Password = "123", Phone = "0987654321" };
            return new JsonResult(_user);
        }

        //query string parameters don't need [HttpGet]
        //http://localhost:5289/api/user/GetUserInfoByEmail/?email=1234567@gmail.com
        public JsonResult GetUserInfoByEmail(string email)
        {
            User _user = new User()
            { Id = 1, UserName = "lily", Email = email, Address = "brisbane", Gender = GenderEnum.Female, Password = "123", Phone = "0987654321" };
            return new JsonResult(_user);

        }
        #endregion

        #region Post
        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromBody
        //{
        //    "Id" : "1", 
        //    "UserName" : "lily", 
        //    "Email" : "lily@gmail.com", 
        //    "Address" : "brisbane", 
        //    "Gender" : 0, 
        //    "Password" : "123", 
        //    "Phone" : "0987654321"
        //}
        public JsonResult AddUserFromBody([FromBody] User user)
        {
            return new JsonResult(user);
        }

        [HttpPost]
        //http://localhost:5289/api/user/AddUserFromForm
        public JsonResult AddUserFromForm([FromForm] User user)
        { 
            return new JsonResult(user); 
        }
        #endregion

        #region
        [HttpPut("{id}")]
        #endregion

        [HttpDelete("{id}")]
    }
}
