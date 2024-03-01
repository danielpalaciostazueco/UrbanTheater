using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class ObraDTO
{
    public ObraDTO() { }

    [Key]
    public int idObjeto { get; set; }
    [Required]
    public int idObra { get; set; }
    [Required]
    public int idSesion { get; set; }
    [Required]
    public int idAsiento { get; set; }
    [Required]
    public bool isFree { get; set; }
}



