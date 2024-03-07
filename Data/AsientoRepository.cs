using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly ILogger<AsientoRepository> _logger;


        public AsientoRepository(UrbanTheaterAppContext context, ILogger<AsientoRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public List<Asiento> GetAll()
        {
            try
            {
                return _context.Asientos.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los asientos por defecto.");
                throw;
            }
        }

    }
}
