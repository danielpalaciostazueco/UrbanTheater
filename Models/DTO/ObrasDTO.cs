using System.ComponentModel.DataAnnotations.Schema; // Importa este espacio de nombres
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class ObrasDTO
{
    public ObrasDTO() { }

    [Key]
    public int IdObjeto { get; set; }
    public int IdObra { get; set; }
    public int IdSesion { get; set; }
    public int IdAsiento { get; set; }
    public bool IsFree { get; set; }
}



