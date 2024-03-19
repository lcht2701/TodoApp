using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Services.Implements;
using DataAccess.Services.Interfaces;
using FluentValidation.AspNetCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var corsPolicy = "CorsPolicy";

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/ToDoApp-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

services.AddControllers();
services.AddFluentValidationAutoValidation();
services.AddFluentValidationClientsideAdapters();
services.AddAutoMapper(Assembly.GetExecutingAssembly());
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<ApplicationDbContext>();

#region Dependency Injection
//Add Repository Base
services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

//Add Services
services.AddScoped<IToDoItemService, ToDoItemService>();
services.AddScoped<ISubItemService, SubItemService>();

#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
