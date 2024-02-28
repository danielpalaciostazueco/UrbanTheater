using System.Collections.Generic;
using UrbanTheater.Models;

namespace UrbanTheater.Data
{
    public interface IAsientoRepository
    {
        List<Asiento> GetAll();
    }
}
