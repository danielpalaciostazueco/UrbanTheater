using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace UrbanTheater.Business
{
    public class HistorialService : IHistorialService
    {
        private readonly IHistorialRepository _historialRepository;
        private readonly ILogger<HistorialService> _logger;


        public HistorialService(IHistorialRepository historialRepository, ILogger<HistorialService> logger)
        {
            _historialRepository = historialRepository;
            _logger = logger;

        }

        public List<Historial> Get(int id)
        {
            try
            {
                return _historialRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los asientos por defecto.");
                throw;
            }
        }

        public void Add(string nombreUsuario, string nombreObra, DateTime fecha, string sesion, int asiento, int idUsuario)
        {
            try
            {
                _historialRepository.Add(nombreUsuario, nombreObra, fecha, sesion, asiento, idUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el historial.");
                throw;
            }
        }
    }
}
