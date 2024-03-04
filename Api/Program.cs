using UrbanTheater.Business;
using UrbanTheater.Api;
using UrbanTheater.Models;
using UrbanTheater.Data;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<UrbanTheaterAppContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

builder.Services.AddScoped<ObraService>();
builder.Services.AddScoped<IObraRepository, ObraRepository>();
builder.Services.AddScoped<AsientoService>();
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:9000","urbantheater.dpalacios.work.gd")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() 
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/Log.Api.txt", 
        restrictedToMinimumLevel: LogEventLevel.Error      
    )
    .CreateLogger();


builder.Host.UseSerilog();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("MyCorsPolicy");
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
