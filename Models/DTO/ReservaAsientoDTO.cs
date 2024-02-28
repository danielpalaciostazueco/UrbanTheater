using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class ReservaAsientoDTO
{
    public ReservaAsientoDTO() { }

    [Required]
    public List<int> asientos { get; set; }
}



