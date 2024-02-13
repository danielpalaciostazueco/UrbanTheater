using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IAsientosRepository
    {
        List<Asientos> GetAll();
        Asientos Get(string id);
        void Update(Asientos asientos);
        Asientos Add(Asientos asientos);
        void Delete(int id);
    }
}
