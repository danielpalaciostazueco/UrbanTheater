using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class ObrasRepository : IObrasRepository
    {
        private readonly UrbanTheaterAppContext _context;

        public ObrasRepository(UrbanTheaterAppContext context)
        {
            _context = context;
        }

        public List<Obras> GetAll()
        {
          
            return _context.Obras.ToList();
        }

        public Obras Get(int id)
        {
            return _context.Obras.FirstOrDefault(obras => obras.ObraID == id);
        }

        public void Add(Obras obras)
        {
            _context.Obras.Add(obras);
            _context.SaveChanges();
        }

        public void Update(Obras obra)
        {
            _context.Entry(obra).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obra = _context.Obras.FirstOrDefault(obras => obras.ObraID == id);
            _context.Obras.Remove(obra);
            _context.SaveChanges();
        }
    }
}
