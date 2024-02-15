using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class AsientosRepository : IAsientosRepository
    {
        private readonly UrbanTheaterAppContext _context;

        public AsientosRepository(UrbanTheaterAppContext context)
        {
            _context = context;
        }
        public List<Asientos> GetAll() => _context.Asientos.ToList();
        public List<AsientosObras> GetAllSeats() => _context.AsientosObras.ToList();
        public AsientosObras GetAllSeatsId(int id) => _context.AsientosObras.FirstOrDefault(x => x.ObraID == id);

    }
}
