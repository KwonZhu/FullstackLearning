using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Practice5.Config;
using System.Text;

namespace Practice5.Init
{
    public static class JwtInitExtension
    {
        public static void AddJWT(this IServiceCollection services, JWTConfig jWTConfig)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jWTConfig.Issuer,
                        ValidateIssuer = true,
                        ValidAudience = jWTConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jWTConfig.SecretKey))
                    };
                });
        }
    }
}
