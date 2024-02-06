using UrbanTheater.Models; // Asume que tus modelos están en este namespace
using UrbanTheater.Data; // Asume que tus repositorios están en este namespace
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class ObrasService :IObrasService
    {
        private readonly IObrasRepository _obraRepository;

        public ObrasService(IObrasRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        public List<Obras> GetAll() => _obraRepository.GetAll();
        public Obras? Get(int id) => _obraRepository.Get(id);
        public void Update(Obras obra) => _obraRepository.Update(obra);
    }
}
