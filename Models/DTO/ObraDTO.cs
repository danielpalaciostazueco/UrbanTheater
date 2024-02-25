using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace UrbanTheater.Models;

public class ObraDTO
{
    public ObraDTO() { }

    [Key]
    public int idObjeto { get; set; }
    public int idObra { get; set; }
    public int idSesion { get; set; }
    public int idAsiento { get; set; }
    public bool isFree { get; set; }
}



