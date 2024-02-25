using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Administrador
{
    public Administrador() { }
    [Key]
    public int idAdministrador { get; set; }
    public string nombreAdministrador { get; set; }
    public string contrasena { get; set; }
}
