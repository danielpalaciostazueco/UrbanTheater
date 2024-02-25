using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IAdministradorRepository
    {
        Administrador? Get(string nombre, string contrasena);
    }
}
