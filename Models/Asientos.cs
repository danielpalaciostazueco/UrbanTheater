using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UrbanTheater.Models;

public class Asientos
{
    public Asientos() { }

    [Key]
    public string idFecha { get; set; }

    public string AsientoOcupado { get; set; }
    [NotMapped]
    public string[] AsientosOcupadosArray
    {
        get => JsonSerializer.Deserialize<string[]>(AsientoOcupado);
        set => AsientoOcupado = JsonSerializer.Serialize(value);
    }
}
