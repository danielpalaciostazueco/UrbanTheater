using System.Collections.Generic;
using UrbanTheater.Models; 

namespace UrbanTheater.Business
{
    public interface IAsientosService
    {
        List<Asiento> GetAll();
    }
}