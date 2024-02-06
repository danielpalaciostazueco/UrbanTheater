using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IObrasRepository
    {
        List<Obras> GetAll();
        Obras Get(int id);
        void Update(Obras obra);
    }
}
