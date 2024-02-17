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


        //------------------------Asientos-------------------------------//

        public List<int> GetObrasAsientos(int ObraID, int IdSesion)
        {
            var asientosId = _context.AsientosObrasDatos
                .Where(id => id.IdObra == ObraID && id.IdSesion == IdSesion)
                .Select(p => p.IdAsiento) // Cambio aquí para seleccionar solo IdAsiento
                .ToList(); // Usar ToList() en lugar de FirstOrDefault()

            return asientosId; // Devuelve la lista de IdAsiento
        }


        public void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree)
        {
            var nuevoAsiento = new AsientosObrasDatos
            {
                IdObra = obraId,
                IdSesion = sessionId,
                IdAsiento = idAsiento,
                IsFree = isFree
            };

            _context.AsientosObrasDatos.Add(nuevoAsiento);
            _context.SaveChanges();
        }


    }
}
