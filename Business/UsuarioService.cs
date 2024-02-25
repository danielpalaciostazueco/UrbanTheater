using UrbanTheater.Data;
using UrbanTheater.Models;

namespace UrbanTheater.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Get(string nombreUsuario, string contrasena)
        {
            return _usuarioRepository.Get(nombreUsuario, contrasena);
        }

        public void AddUsuario(Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
        }
    }
}
