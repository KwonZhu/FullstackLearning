using Microsoft.AspNetCore.Mvc;
using Practice5.Config;
using Practice5.IServices;
using Practice5.Services;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DBConnectionConfig>(builder.Configuration);

// disable  auto model validation
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
