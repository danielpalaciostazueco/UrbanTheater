using UrbanTheater.Data;
using UrbanTheater.Models;

namespace UrbanTheater.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly FileLogger _logger = new FileLogger("Log.Business.txt");

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Get(string nombreUsuario, string contrasena)
        {
            try
            {
                return _usuarioRepository.Get(nombreUsuario, contrasena);
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
                _usuarioRepository.AddUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.Log($"AddUsuario fallado: {ex.Message}");
            }
        }
    }
}
