using UrbanTheater.Business;
using UrbanTheater.Api;
using UrbanTheater.Models;
using UrbanTheater.Data;
using TetePizza.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UrbanTheaterAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ObrasService>();
builder.Services.AddScoped<IObrasRepository, ObrasRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:9000") // Asegúrate de reemplazar esto con el origen correcto
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();  
app.UseCors("MyCorsPolicy");
//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
