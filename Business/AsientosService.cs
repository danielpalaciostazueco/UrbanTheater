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

        public List<Asientos> GetAll()
        {
            return _asientosRepository.GetAll();
        }

        public List<AsientosObras> GetAllSeats()
        {
            return _asientosRepository.GetAllSeats();
        }

        public AsientosObras GetAllSeatsId(int id)
        {
            return _asientosRepository.GetAllSeatsId(id);
        }



    }
}
