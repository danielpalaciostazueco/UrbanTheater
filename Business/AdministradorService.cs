using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public Administrador? Get(string nombre, string contrasena) =>
            _administradorRepository.Get(nombre, contrasena);
    }
}
