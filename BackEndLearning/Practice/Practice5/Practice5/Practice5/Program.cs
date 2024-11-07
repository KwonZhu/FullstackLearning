using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practice5.Config;
using Practice5.Filters;
using Practice5.Init;
using Practice5.IServices;
using Practice5.Models;
using Practice5.Services;
using System.Data.Common;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//ADO.NET config
builder.Services.Configure<DBConnectionConfig>(builder.Configuration);

//ORM config
var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));
var connectionString = builder.Configuration["DBConnection"];
builder.Services.AddDbContext<MoocDBContext>(
    dbContextOptions => dbContextOptions
    .UseMySql(connectionString, serverVersion)
    //the following three options help with debugging, but should
    // be changed or removed for production.
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    );

//JWT config
//this JWTConfig need to be used in CreateTokenService
builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));
//this jwtConfig need to be used in this program.cs
var jwtConfig = builder.Configuration.GetSection("JWTConfig").Get<JWTConfig>();
builder.Services.AddJWT(jwtConfig);

// disable  auto model validation
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddControllers(options =>
{
    //global filter register, working for all actions
    //options.Filters.Add<ActionFilter>();
    //options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<ResultFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
