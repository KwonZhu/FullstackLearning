using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Practice5.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice5.Services
{
    public class CreateTokenService
    {
        private readonly JWTConfig jWTConfig;

        public CreateTokenService(IOptions<JWTConfig> options)
        {
            this.jWTConfig = options.Value;
        }

        public string CreateToken(Dictionary<string, string> payBody)
        {
            var claims = new List<Claim>();
            foreach (var item in payBody)
                claims.Add(new Claim(item.Key, item.Value));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jWTConfig.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: this.jWTConfig.Issuer,
               audience: this.jWTConfig.Audience,
               claims: claims,
               expires: DateTimeOffset.Now.LocalDateTime.AddSeconds(this.jWTConfig.ExpireSeconds),
               signingCredentials: creds);

            var jwtHandel = new JwtSecurityTokenHandler();
            var accessToken = jwtHandel.WriteToken(token);

            return accessToken;
        }

    }
}
