using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Collections.Generic;
using System.Linq;
using UrbanTheater.Data;

namespace UrbanTheater.Data
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly UrbanTheaterAppContext _context;

        public AdministradorRepository(UrbanTheaterAppContext context)
        {
            _context = context;
        }

        public Administrador Get(string nombre, string contrasena)
        {
            return _context.Administradores.AsNoTracking().FirstOrDefault(admin => admin.nombreAdministrador == nombre && admin.contrasena == contrasena);
        }
    }
}
