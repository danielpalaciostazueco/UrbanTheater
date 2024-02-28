using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class AsientosObrasDatos
{
    public AsientosObrasDatos() { }
    [Key]
    public int idObjeto { get; set; }
    public int idObra { get; set; }
    public int idSesion { get; set; }
    public int idAsiento { get; set; }
}
