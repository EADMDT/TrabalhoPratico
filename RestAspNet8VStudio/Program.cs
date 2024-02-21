using RestAspNet8VStudio.Services;
using RestAspNet8VStudio.Services.Implementations;
using RestAspNet8VStudio.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connection = builder.Configuration["PostgreConnection:PostgreConnectionString"];
builder.Services.AddDbContext<PostgreSQLContext>(options => options.UseNpgsql(
    connection));

builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IUserService, UserServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
