using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Asiento
{
    public Asiento() { }
    [Key]
    public int idAsiento { get; set; }
    public bool isFree { get; set; }

}
