using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IObrasRepository
    {
        List<Obras> GetAll();
        Obras Get(int id);
        void Update(Obras obra);
        void Add(Obras obra);
        void Delete(int id);
        List<int> GetObrasAsientos(int ObraID, int IdSesion);
        void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree);
    }
}
