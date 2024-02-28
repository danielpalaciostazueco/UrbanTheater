using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly FileLogger _logger = new FileLogger("Log.Business.txt");

        public AsientoService(IAsientoRepository asientoRepository)
        {
            try
            {
                _asientoRepository = asientoRepository;
            }
            catch (Exception ex)
            {
                _logger.Log($"AsientoService fallado: {ex.Message}");
            }

        }

        public List<Asiento> GetAll()
        {
            try
            {
                return _asientoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll de Asiento fallado: {ex.Message}");
                return null;
            }
        }
    }
}
