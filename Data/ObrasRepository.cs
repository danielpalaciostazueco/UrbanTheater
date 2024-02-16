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

        public ObrasDTO GetObrasAsientos(int ObraID, int IdSesion)
        {
            var Obras = _context.AsientosObrasDatos
            .Where(id => id.IdObra == ObraID && id.IdSesion == IdSesion)
            .Select(p => new ObrasDTO
            {
                IdObra = p.IdObra,
                IdSesion = p.IdSesion,
                IdAsiento = p.IdAsiento,
                IsFree = p.IsFree

            }).FirstOrDefault();

            return Obras;
        }

        public void PostObrasAsientos(ObrasDTO asientos)
        {
            var obra = _context.AsientosObrasDatos
            .Where(id => id.IdObra == asientos.IdObra && id.IdSesion == asientos.IdSesion && id.IdAsiento == asientos.IdAsiento)
            .FirstOrDefault();

            if (obra != null)
            {
                var newObra = new AsientosObrasDatos
                {
                    IdObra = asientos.IdObra,
                    IdSesion = asientos.IdSesion,
                    IdAsiento = asientos.IdAsiento + 1,
                    IsFree = asientos.IsFree
                };



            }
            else//Parte para  gestionar si no existe el asiento en la obra
            {
                var newObra = new AsientosObrasDatos
                {
                    IdObra = asientos.IdObra,
                    IdSesion = asientos.IdSesion,
                    IdAsiento = asientos.IdAsiento,
                    IsFree = asientos.IsFree
                };
                _context.AsientosObrasDatos.Add(newObra);
            }
            _context.SaveChanges();
        }
    }
}
