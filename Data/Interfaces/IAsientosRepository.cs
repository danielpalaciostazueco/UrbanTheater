using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IAsientosRepository
    {
        List<Asientos> GetAll();
        List<AsientosObras> GetAllSeats();
        AsientosObras GetAllSeatsId(int id);


    }
}
