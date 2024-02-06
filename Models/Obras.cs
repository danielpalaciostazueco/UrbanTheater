namespace UrbanTheater.Models;

public class Obras
{

    public int ObraID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public List<string> Autores { get; set; } 
    public decimal Duracion { get; set; }
    public List<string> Actores { get; set; } 
    public List<string> Imagenes { get; set; } 
    public string Fechas { get; set; }
    public string Slug { get; set; }
    public string Cartel { get; set; }
}
