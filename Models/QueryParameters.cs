using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UrbanTheater.Models;

public class QueryParameters
{
    public QueryParameters() { }

    
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Autores { get; set; }
    public int? Duracion { get; set; }
     public string? Actores { get; set; }
     public DateTime? FechaUno { get; set; }
 
    public DateTime? FechaDos { get; set; }
  
    public DateTime? FechaTres { get; set; }
 
  
}
