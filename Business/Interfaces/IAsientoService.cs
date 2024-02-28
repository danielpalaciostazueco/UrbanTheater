using System.Collections.Generic;
using UrbanTheater.Models; 

namespace UrbanTheater.Business
{
    public interface IAsientoService
    {
        List<Asiento> GetAll();
    }
}