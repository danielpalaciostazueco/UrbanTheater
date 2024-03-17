using UrbanTheater.Business;
using UrbanTheater.Api;
using UrbanTheater.Models;
using UrbanTheater.Data;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Obtén la cadena de conexión de tu archivo de configuración (appsettings.json u otro)
var keyString = "ServerDB";
var connectionString = builder.Configuration.GetConnectionString(keyString);

// Configuración de los servicios para la aplicación
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de Entity Framework para usar SQL Server
builder.Services.AddDbContext<UrbanTheaterAppContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

// Configuración de los servicios de la aplicación
builder.Services.AddScoped<ObraService>();
builder.Services.AddScoped<IObraRepository, ObraRepository>();
builder.Services.AddScoped<AsientoService>();
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<HistorialService>(); 
builder.Services.AddScoped<IHistorialRepository, HistorialRepository>();



// Configuración de CORS para permitir solicitudes de cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        policy => policy
            .WithOrigins("*") // Permite solicitudes de cualquier origen
            .AllowAnyMethod() // Permite todos los métodos HTTP
            .AllowAnyHeader()); // Permite todas las cabeceras HTTP
});

// Configuración de Serilog para logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/Log.Api.txt", restrictedToMinimumLevel: LogEventLevel.Error)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configuración del middleware para utilizar Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// Aplica la política CORS configurada
app.UseCors("MyCorsPolicy");

app.UseAuthorization();

// Mapeo de los controladores
app.MapControllers();

// Inicia la aplicación
app.Run();
