using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
using System.Linq;

namespace UrbanTheater.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UrbanTheaterAppContext _context;

        public UsuarioRepository(UrbanTheaterAppContext context)
        {
            _context = context;
        }

        public Usuario Get(string nombreUsuario, string contrasena)
        {
            var usuario = _context.Usuarios
                                  .Where(u => u.nombreUsuario == nombreUsuario && u.contrasena == contrasena)
                                  .ToList()
                                  .FirstOrDefault();

            return usuario;
        }


        public void AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
