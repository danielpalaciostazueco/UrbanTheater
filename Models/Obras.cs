using System.ComponentModel.DataAnnotations.Schema; // Importa este espacio de nombres
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Asegúrate de tener esta directiva para la serialización
using System.Text.Json; // Para usar JsonSerializer

namespace UrbanTheater.Models;

public class Obras
{
    public Obras() { }

    [Key]
    public int ObraID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public string Autores { get; set; }
    public decimal Duracion { get; set; }
    public string Actores { get; set; }
    public string Imagenes { get; set; }
    public string Fechas { get; set; }
    public string Slug { get; set; }
    public string Cartel { get; set; }

    // Propiedades no mapeadas para manejo en la aplicación
    [NotMapped]
    public string[] AutoresArray
    {
        get => JsonSerializer.Deserialize<string[]>(Autores);
        set => Autores = JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public string[] ActoresArray
    {
        get => JsonSerializer.Deserialize<string[]>(Actores);
        set => Actores = JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public string[] ImagenesArray
    {
        get => JsonSerializer.Deserialize<string[]>(Imagenes);
        set => Imagenes = JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public string[] FechasArray
    {
        get => JsonSerializer.Deserialize<string[]>(Fechas);
        set => Fechas = JsonSerializer.Serialize(value);
    }
}
