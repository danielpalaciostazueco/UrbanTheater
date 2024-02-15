using System.Collections.Generic;
using UrbanTheater.Models; // Asegúrate de que el namespace sea correcto para tus modelos

namespace UrbanTheater.Business
{
    public interface IAsientosService
    {
        List<Asientos> GetAll();
        List<AsientosObras> GetAllSeats();
        AsientosObras GetAllSeatsId(int id);


    }
}