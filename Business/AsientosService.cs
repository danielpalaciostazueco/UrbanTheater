using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class AsientosService : IAsientosService
    {
        private readonly IAsientosRepository _asientosRepository;

        public AsientosService(IAsientosRepository asientosRepository)
        {
            _asientosRepository = asientosRepository;
        }

        public Asientos Get(string id) => _asientosRepository.Get(id);

        public void Update(Asientos asientos) => _asientosRepository.Update(asientos);

        public Asientos Add(Asientos asientos)
        {
            var existingAsiento = _asientosRepository.Get(asientos.idFecha);
            if (existingAsiento != null)
            {
                existingAsiento.AsientosOcupadosArray = MergeAsientos(existingAsiento.AsientosOcupadosArray, asientos.AsientosOcupadosArray);
                _asientosRepository.Update(existingAsiento);
                return existingAsiento;
            }
            else
            {
                return _asientosRepository.Add(asientos);
            }
        }

        private string[] MergeAsientos(string[] existingAsientos, string[] newAsientos)
        {
            var combinedAsientos = existingAsientos.Concat(newAsientos).Distinct().ToArray();
            return combinedAsientos;
        }
    }
}
