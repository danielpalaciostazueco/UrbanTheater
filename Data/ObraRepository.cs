using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class ObraRepository : IObraRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly FileLogger _logger = new FileLogger("Log.Data.txt");

        public ObraRepository(UrbanTheaterAppContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception ex)
            {
                _logger.Log($"ObraRepository fallado: {ex.Message}");
            }
        }

        public List<Obra> GetAll()
        {
            try
            {
                return _context.Obras.ToList();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll de Obra fallado: {ex.Message}");
                return null;
            }

        }

        public Obra Get(int id)
        {
            try
            {
                return _context.Obras.AsNoTracking().FirstOrDefault(obras => obras.ObraID == id);
            }
            catch (Exception ex)
            {
                _logger.Log($"Get de Obra fallado: {ex.Message}");
                return null;
            }
        }

        public Obra GetByName(string name)
        {
            try
            {
                return _context.Obras.AsNoTracking().FirstOrDefault(obras => obras.Nombre == name);
            }
            catch (Exception ex)
            {
                _logger.Log($"Get de Obra fallado: {ex.Message}");
                return null;

            }
        }
        public void Add(Obra obras)
        {
            try
            {
                _context.Obras.Add(obras);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log($"Add de Obra fallado: {ex.Message}");

            }
        }

        public void Update(Obra obra)
        {
            try
            {
                _context.Entry(obra).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log($"Update de Obra fallado: {ex.Message}");

            }
        }


        public void Delete(int id)
        {
            try
            {
                var obra = _context.Obras.FirstOrDefault(obras => obras.ObraID == id);
                _context.Obras.Remove(obra);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log($"Delete de Obra fallado: {ex.Message}");

            }
        }


        public List<int> GetObrasAsientos(int ObraID, int IdSesion)
        {
            try
            {
                var asientosId = _context.AsientosObrasDatos
                    .Where(id => id.idObra == ObraID && id.idSesion == IdSesion)
                    .Select(p => p.idAsiento)
                    .ToList();

                return asientosId;
            }
            catch (Exception ex)
            {
                _logger.Log($"GetObrasAsientos de Obra fallado: {ex.Message}");
                return null;
            }
        }


        public void AddAsientoToObra(int obraId, int sessionId, int idAsiento)
        {
            try
            {
                var nuevoAsiento = new AsientosObrasDatos
                {
                    idObra = obraId,
                    idSesion = sessionId,
                    idAsiento = idAsiento,
                };

                _context.AsientosObrasDatos.Add(nuevoAsiento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log($"AddAsientoToObra de Obra fallado: {ex.Message}");

            }
        }


    }
}
