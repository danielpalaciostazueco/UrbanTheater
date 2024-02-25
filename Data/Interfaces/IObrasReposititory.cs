using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IObrasRepository
    {
        List<Obra> GetAll();
        Obra Get(int id);
        void Update(Obra obra);
        void Add(Obra obra);
        void Delete(int id);
        List<int> GetObrasAsientos(int ObraID, int IdSesion);
        void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree);
    }
}
