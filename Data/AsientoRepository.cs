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

        public AsientoRepository(UrbanTheaterAppContext context)
        {
            _context = context;
        }
        public List<Asiento> GetAll() => _context.Asientos.ToList();

    }
}
