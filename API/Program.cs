using BusinessObject.Mappings;
using BusinessObject.Validations.SubItems;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Services.Implements;
using DataAccess.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var corsPolicy = "CorsPolicy";

var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/ToDoApp-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

services.AddControllers();
services.AddFluentValidationAutoValidation()
        .AddFluentValidationClientsideAdapters()
        .AddValidatorsFromAssemblyContaining<CreateSubItemValidator>();
services.AddAutoMapper(typeof(MappingProfile));
services.AddDbContext<ApplicationDbContext>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
