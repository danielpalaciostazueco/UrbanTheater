using UrbanTheater.Data;
using UrbanTheater.Models;
using Microsoft.Extensions.Logging; 

namespace UrbanTheater.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
         private readonly ILogger<UsuarioService> _logger; 
     

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger; 
        }

        public Usuario Get(string nombreUsuario, string contrasena)
        {
            try
            {
                return _usuarioRepository.Get(nombreUsuario, contrasena);
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, "Error obteniendo el usuario.");
                throw;
            }
        }

        public void AddUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepository.AddUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el usuario.");
                throw;
            }
        }
    }
}
