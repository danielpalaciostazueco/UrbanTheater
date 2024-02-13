using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class ObrasService : IObrasService
    {
        private readonly IObrasRepository _obraRepository;

        public ObrasService(IObrasRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        public List<Obras> GetAll() => _obraRepository.GetAll();
        public Obras? Get(int id) => _obraRepository.Get(id);
        public void Update(Obras obra) => _obraRepository.Update(obra);
        public void Add(Obras obra) => _obraRepository.Add(obra);
    }
}
