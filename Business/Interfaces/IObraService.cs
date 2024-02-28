using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IObraService
    {
        List<Obra> GetAll();
        Obra? Get(int id);
        Obra GetByName(string name);
        void Update(Obra obra);
        void Add(Obra obra);
        void Delete(int id);
        List<int> GetObrasAsientos(int ObraID, int IdSesion);
        void AddAsientoToObra(int obraId, int sessionId, int idAsiento);

    }
}