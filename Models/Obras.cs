using System.ComponentModel.DataAnnotations;
namespace UrbanTheater.Models;

public class Obras
{
    public Obras () { }

    [Key]
    public int ObraID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string  Autores { get; set; } 
    public decimal Duracion { get; set; }
    public string Actores { get; set; } 
    public string Imagenes { get; set; } 
    public string Fechas { get; set; }
    public string Slug { get; set; }
    public string Cartel { get; set; }
}
