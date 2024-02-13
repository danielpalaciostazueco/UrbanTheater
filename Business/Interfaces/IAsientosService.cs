using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IAsientosService
    {
        Asientos Get(string id);
        void Update(Asientos asientos);
        Asientos Add(Asientos asientos);
    }
}