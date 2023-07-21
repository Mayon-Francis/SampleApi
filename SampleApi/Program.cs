using SampleApi.Data;
using Microsoft.EntityFrameworkCore;
using SampleApi.Services;
using SampleApi.Helpers;
using SampleApi.Services.Interfaces;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEnvironmentService, EnvironmentService>();

// To use in-memory database
// builder.Services.AddDbContext<SampleAPIDbContext>(options => options.UseInMemoryDatabase("SampleAPIDb"));

builder.Services.AddDbContext<SampleAPIDbContext>(options =>
{
    IEnvironmentService environmentService = builder.Services.BuildServiceProvider().GetRequiredService<IEnvironmentService>();
    options.UseNpgsql(environmentService.POSTGRES_CONNECTION_STRING);
});

var app = builder.Build();

new StartupHelper(app.Services.GetRequiredService<IEnvironmentService>());

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    // Use swagger
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:5000");
