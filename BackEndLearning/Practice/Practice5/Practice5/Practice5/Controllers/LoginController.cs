using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice5.IServices;
using Practice5.Services;
using Practice5.ViewModels;

namespace Practice5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        private readonly CreateTokenService _createTokenService;
        public LoginController(IUserService userService, CreateTokenService createTokenService, ILogger<LoginController> logger)
        {
            this._userService = userService;
            this._createTokenService = createTokenService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public LoginOutput Login(LoginInput input)
        {
            var user = this._userService.GetUserByUserName(input.UserName);
            this._logger.LogWarning("this is a log warning test");
            this._logger.LogError("this is a log error test");
            this._logger.LogDebug("this is a log debug test");
            if (user == null)
            {
                return null;
            }

            if (user.Password == input.Password)
            {
                Dictionary<string, string> payBody = new Dictionary<string, string>();
                payBody.Add("UserId", user.Id.ToString());
                payBody.Add("UserName", user.UserName);
                payBody.Add("Email", user.Email);
                var accessToken = this._createTokenService.CreateToken(payBody);

                var result = new LoginOutput()
                {
                    Id = user.Id,
                    UerName = input.UserName,
                    AccessToken = accessToken,
                };
                return result;
            }

            return null;
        }
    }
}
