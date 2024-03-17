using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class HistorialRepository : IHistorialRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly ILogger<HistorialRepository> _logger;


        public HistorialRepository(UrbanTheaterAppContext context, ILogger<HistorialRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public List<Historial> Get(int idUsuario)
        {
            try
            {

                return _context.Historial.Where(x => x.idUsuario == idUsuario).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el historial por id de usuario.");
                throw;
            }
        }

        public void Add(string nombreUsuario, string nombreObra, System.DateTime fecha, string sesion, int asiento, int idUsuario)
        {
            try
            {
                var historial = new Historial
                {
                    nombreUsuario = nombreUsuario,
                    nombreObra = nombreObra,
                    fecha = fecha,
                    sesion = sesion,
                    asiento = asiento,
                    idUsuario = idUsuario
                };

                _context.Historial.Add(historial);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el historial.");
                throw;
            }
        }
    }
}
