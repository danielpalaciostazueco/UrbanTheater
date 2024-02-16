using System.ComponentModel.DataAnnotations.Schema; // Importa este espacio de nombres
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class AsientosDTO
{
    public AsientosDTO() { }


    public List<int> asientos { get; set; }
}



