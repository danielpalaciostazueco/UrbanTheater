using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly FileLogger _logger = new FileLogger("Log.Data.txt");

        public AsientoRepository(UrbanTheaterAppContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception ex)
            {
                _logger.Log($"AsientoRepository fallado: {ex.Message}");
            }
        }
        public List<Asiento> GetAll()
        {
            try
            {
                return _context.Asientos.ToList();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll de Asiento fallado: {ex.Message}");
                return null;
            }
        }

    }
}
