using System.ComponentModel.DataAnnotations.Schema; // Importa este espacio de nombres
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class AsientosObras
{
    public AsientosObras() { }

    [Key]
    public int ObraID { get; set; }
    public int Event { get; set; }
    public int IdAsiento { get; set; }
    public bool IsFree { get; set; }

}
