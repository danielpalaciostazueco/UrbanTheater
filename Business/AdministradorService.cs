using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly FileLogger _logger = new FileLogger("Log.Business.txt");

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            try
            {
                _administradorRepository = administradorRepository;
            }
            catch (Exception ex)
            {
                _logger.Log($"AdministradorService fallado: {ex.Message}");
            }
        }

        public Administrador? Get(string nombre, string contrasena)
        {
            try
            {
                return _administradorRepository.Get(nombre, contrasena);
            }
            catch (Exception ex)
            {
                _logger.Log($"Get de Administrador fallado: {ex.Message}");
                return null;
            }
        }
    }
}
