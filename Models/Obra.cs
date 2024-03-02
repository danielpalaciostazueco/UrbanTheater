using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UrbanTheater.Models;

public class Obra
{
    public Obra() { }

    [Key]
    public int ObraID { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Descripcion { get; set; }
    [Required]
    public string? Autores { get; set; }
    [Required]
    public int? Duracion { get; set; }
    [Required]
    public string? Actores { get; set; }
    [Required]
    public string? Imagenes { get; set; }
    [Required]
    public DateTime FechaUno { get; set; }
    [Required]
    public DateTime FechaDos { get; set; }
    [Required]
    public DateTime FechaTres { get; set; }
    [Required]
    public string Cartel { get; set; }
}
