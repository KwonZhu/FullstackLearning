using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Practice5.Config;
using Practice5.Filters;
using Practice5.Init;
using Practice5.IServices;
using Practice5.Models;
using Practice5.Services;
using System.Data.Common;
using System.Reflection;
using System.Text;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    var policyName = "defalutPolicy";
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
    //be changed or removed for production.
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

    //config swagger
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "My First Web Api Project",
            Version = "v1",
            Description = "This is my First Web Api Project",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Kwon", Url = new Uri("https://google.com") }
        });

        var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);

        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            Description = "",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
        {
            new OpenApiSecurityScheme()
            {
                Reference=new OpenApiReference()
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new List<string>()
        }
        });
    });

    //config cors
    builder.Services.AddCors(option =>
    {
        option.AddPolicy(policyName, policy =>
        {

            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });

    // disable  auto model validation
    builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

    // Add services to the container.
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<ICategoryService, CategoryService>();
    builder.Services.AddTransient<CreateTokenService>();
    //builder.Services.AddTransient<PermissionCodeAttribute>();

    builder.Services.AddControllers(options =>
    {
        //global filter register, working for all actions
        //options.Filters.Add<ActionFilter>();
        //options.Filters.Add<ExceptionFilter>();
        options.Filters.Add<ResultFilter>();
        options.Filters.Add<AuthorizeFilter>();
    });

    //NLog: Configuring Logging Providers
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseCors(policyName);

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program becauese of exception");

}
finally
{
    NLog.LogManager.Shutdown();
}