using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Asientos
{
    [Key]
    public int IdAsiento { get; set; }
    public bool IsFree { get; set; }

}
