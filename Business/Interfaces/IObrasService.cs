using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IObrasService
    {
        List<Obras> GetAll();
        Obras Get(int id);
        void Update(Obras obra);
    }
}