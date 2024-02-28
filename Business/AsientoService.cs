using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;

        public AsientoService(IAsientoRepository asientoRepository)
        {
            _asientoRepository = asientoRepository;
        }

        public List<Asiento> GetAll()
        {
            return _asientoRepository.GetAll();
        }
    }
}
