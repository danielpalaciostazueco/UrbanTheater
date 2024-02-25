using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Usuario
{
    public Usuario() { }
    [Key]
    public int idUsuario { get; set; }
    public string nombreUsuario { get; set; }
    public string contrasena { get; set; }
}