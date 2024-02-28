using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Linq;

namespace UrbanTheater.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UrbanTheaterAppContext _context;
        private readonly FileLogger _logger = new FileLogger("Log.Data.txt");

        public UsuarioRepository(UrbanTheaterAppContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception ex)
            {
                _logger.Log($"UsuarioRepository fallado: {ex.Message}");
            }
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
                _logger.Log($"Get de Usuario fallado: {ex.Message}");
                return null;
            }
        }


        public void AddUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log($"AddUsuario fallado: {ex.Message}");
            }
        }
    }
}
