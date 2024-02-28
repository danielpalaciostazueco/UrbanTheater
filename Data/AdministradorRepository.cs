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
        private readonly FileLogger _logger = new FileLogger("Log.Data.txt");

        public AdministradorRepository(UrbanTheaterAppContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception ex)
            {
                _logger.Log($"AdministradorRepository fallado: {ex.Message}");
            }
        }

        public Administrador Get(string nombre, string contrasena)
        {
            try
            {
                return _context.Administradores.AsNoTracking().FirstOrDefault(admin => admin.nombreAdministrador == nombre && admin.contrasena == contrasena);
            }
            catch (Exception ex)
            {
                _logger.Log($"Get de Administrador fallado: {ex.Message}");
                return null;
            }
        }
    }
}
