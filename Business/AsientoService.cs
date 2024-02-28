using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging; 

namespace UrbanTheater.Business
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly ILogger<AsientoService> _logger; 
       

        public AsientoService(IAsientoRepository asientoRepository, ILogger<AsientoService> logger)
        {
                _asientoRepository = asientoRepository;
                 _logger = logger; 
           
        }

        public List<Asiento> GetAll()
        {
            try
            {
                return _asientoRepository.GetAll();
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "Error obteniendo los asientos por defecto.");
                throw; 
            }
        }
    }
}
