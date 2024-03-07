using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace UrbanTheater.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly ILogger<UsuarioRepository> _logger;


        public UsuarioRepository(UrbanTheaterAppContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Usuario Get(string nombreUsuario, string contrasena)
        {
            try
            {
                return _context.Usuarios
                              .Where(u => u.nombreUsuario == nombreUsuario && u.contrasena == contrasena)
                              .ToList()
                              .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el ususario.");
                throw;

            }
        }


        public void AddUsuario(Usuario usuario)
        {
            try
            {
                usuario.rol = 3;
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el usuario.");
                throw;
            }
        }
    }
}
