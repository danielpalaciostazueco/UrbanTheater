using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IObrasRepository
    {
        List<Obras> GetAll();
        Obras Get(int id);
        void Update(Obras obra);
        void Add(Obras obras);
        void Delete(int id);
        ObrasDTO GetObrasAsientos(int Id, int Sesion);
        void PostObrasAsientos(ObrasDTO asientos);
    }
}
