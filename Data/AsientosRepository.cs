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

        public Asientos Get(string id)
        {
            return _context.Asientos.FirstOrDefault(a => a.idFecha == id);
        }

        public Asientos Add(Asientos asientos)
        {
            _context.Asientos.Add(asientos);
            _context.SaveChanges();
            return asientos;
        }

        public void Update(Asientos asientos)
        {
            var existingAsiento = _context.Asientos.FirstOrDefault(a => a.idFecha == asientos.idFecha);
            if (existingAsiento != null)
            {
                existingAsiento.AsientoOcupado = asientos.AsientoOcupado;
                _context.Entry(existingAsiento).State = EntityState.Modified;
            }
            else
            {
                _context.Asientos.Add(asientos);
            }

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var asientos = _context.Asientos.Find(id);
            _context.Asientos.Remove(asientos);
            _context.SaveChanges();
        }
    }
}
