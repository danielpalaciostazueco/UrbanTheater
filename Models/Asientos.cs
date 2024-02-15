using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Asientos
{
    [Key]
    public int IdAsiento { get; set; }
    public bool IsFree { get; set; }
    public int ObraID { get; set; } // Necesario para vincular asiento con una obra
    public int Event { get; set; } // Necesario para vincular asiento con un evento
}
