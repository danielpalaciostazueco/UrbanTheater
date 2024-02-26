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

        public List<Obra> GetAll()
        {

            return _context.Obras.ToList();
        }

        public Obra Get(int id)
        {
            return _context.Obras.AsNoTracking().FirstOrDefault(obras => obras.ObraID == id);
        }

        public Obra GetByName(string name)
        {
            return _context.Obras.AsNoTracking().FirstOrDefault(obras => obras.Nombre == name);
        }
        public void Add(Obra obras)
        {
            _context.Obras.Add(obras);
            _context.SaveChanges();
        }

        public void Update(Obra obra)
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
                .Where(id => id.idObra == ObraID && id.idSesion == IdSesion)
                .Select(p => p.idAsiento)
                .ToList();

            return asientosId;
        }


        public void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree)
        {
            var nuevoAsiento = new AsientosObrasDatos
            {
                idObra = obraId,
                idSesion = sessionId,
                idAsiento = idAsiento,
                isFree = isFree
            };

            _context.AsientosObrasDatos.Add(nuevoAsiento);
            _context.SaveChanges();
        }


    }
}
