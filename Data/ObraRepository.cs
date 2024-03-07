using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class ObraRepository : IObraRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly ILogger<ObraRepository> _logger;


        public ObraRepository(UrbanTheaterAppContext context, ILogger<ObraRepository> logger)
        {

            _context = context;
            _logger = logger;
        }

        public List<Obra> GetAll()
        {

            return _context.Obras.ToList();



        }

        public Obra Get(int id)
        {
            try
            {
                return _context.Obras.AsNoTracking().FirstOrDefault(obras => obras.ObraID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo obra por id.");
                throw;

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
                _logger.LogError(ex, "Error obteniendo la obra por nombre.");
                throw;
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
                _logger.LogError(ex, "Error al añadir la obra.");
                throw;
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
                _logger.LogError(ex, "Error al añadir la obra.");
                throw;
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
                _logger.LogError(ex, "Error al eliminar la obra.");
                throw;

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
                _logger.LogError(ex, "Error al obtener los asientos ocupados.");
                throw;

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
                _logger.LogError(ex, "Error añadir los asientos ocupados.");
                throw;
            }
        }


    }
}
