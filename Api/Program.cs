using UrbanTheater.Business;
using UrbanTheater.Api;
using UrbanTheater.Models;
using UrbanTheater.Data;
using TetePizza.Controllers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ObrasController>();
builder.Services.AddScoped<ObrasService>();
builder.Services.AddScoped<IObrasRepository, ObrasSqlRepository>(serviceProvider =>
new ObrasSqlRepository(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
