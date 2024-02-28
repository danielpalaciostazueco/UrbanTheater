using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class AsientosObrasDatos
{
    public AsientosObrasDatos() { }
    [Key]
    public int idObjeto { get; set; }
    [Required]
    public int idObra { get; set; }
    [Required]
    public int idSesion { get; set; }
    [Required]
    public int idAsiento { get; set; }
}
