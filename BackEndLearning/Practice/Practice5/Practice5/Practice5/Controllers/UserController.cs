using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Practice5.Enum;
using Practice5.IServices;
using Practice5.Models;
using Practice5.ViewModels;

namespace Practice5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public CommonResult AddUser(AddUserInput input)
        {
            CommonResult commonResult = new CommonResult();
            if (!ModelState.IsValid)
            {
                commonResult.Success = false;
                commonResult.Message = "Validaitons are failed";

                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        commonResult.Errors.Add(error.ErrorMessage);
                    }
                }
                return commonResult;
            }
            var user = new User()
            {
                UserName = input.UserName,
                Password = input.Password,
                Email = input.Email,
                Age = input.Age,
                Gender = input.Gender,
                Address = input.Address,
                Phone = input.Phone

            };
            var success = this._userService.AddUser(user);
            commonResult.Success = success;
            return commonResult;
        }
    }
}
