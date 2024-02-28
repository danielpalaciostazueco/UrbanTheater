using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Asiento
{
    public Asiento() { }
    [Key]
    public int idAsiento { get; set; }
    [Required]
    public bool isFree { get; set; }

}
