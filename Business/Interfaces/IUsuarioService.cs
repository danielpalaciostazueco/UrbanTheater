using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IUsuarioService
    {
        Usuario Get(string nombreUsuario, string contrasena);
        void AddUsuario(Usuario usuario);
    }
}