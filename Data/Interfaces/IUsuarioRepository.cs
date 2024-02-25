using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IUsuarioRepository
    {
        Usuario Get(string nombreUsuario, string contrasena);
        void AddUsuario(Usuario usuario);
    }
}
