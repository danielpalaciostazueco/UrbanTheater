using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IObrasService
    {
        List<Obras> GetAll();
        Obras? Get(int id);
        void Update(Obras obra);
        void Add(Obras obra);
        void Delete(int id);
        List<int> GetObrasAsientos(int ObraID, int IdSesion);
        void AddAsientoToObra(int obraId, int sessionId, int idAsiento, bool isFree);

    }
}