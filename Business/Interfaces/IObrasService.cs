using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IObrasService
    {
        List<Obras> GetAll();
        Obras Get(int id);
        void Update(Obras obra);
        void Add(Obras obra);
        ObrasDTO GetObrasAsientos(int Id, int Sesion);
        void PostObrasAsientos(ObrasDTO asientos);

    }
}