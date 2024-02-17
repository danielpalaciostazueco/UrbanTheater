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
        public void Delete(int id) => _obraRepository.Delete(id);

        //-------------Asientos------------------------------------------------//

        public List<int> GetObrasAsientos(int ObraID, int IdSesion)
        {
            return _obraRepository.GetObrasAsientos(ObraID, IdSesion);
        }


        public void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree)
        {
            _obraRepository.AddAsientoToObra(obraId, sessionId, idAsiento, isFree);
        }


    }
}
