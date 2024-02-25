using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IAdministradorService
    {
        Administrador? Get(string nombre, string contrasena);
    }
}