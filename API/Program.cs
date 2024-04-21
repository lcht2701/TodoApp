using BusinessObject.Mappings;
using BusinessObject.Validations.SubItems;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Services.Implements;
using DataAccess.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
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
services.AddAutoMapper(typeof(MappingProfile));
services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(configuration.GetConnectionString("ToDoAppDbString")));
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
#region Fluent Validation
services.AddFluentValidationAutoValidation()
        .AddFluentValidationClientsideAdapters()
        .AddValidatorsFromAssemblyContaining<CreateSubItemValidator>();
#endregion

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
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
