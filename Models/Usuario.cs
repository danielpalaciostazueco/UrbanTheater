using System.ComponentModel.DataAnnotations;

namespace UrbanTheater.Models;

public class Usuario
{
    public Usuario() { }
    [Key]
    public int idUsuario { get; set; }
    [Required]
    public string nombreUsuario { get; set; }
    [Required]
    public string contrasena { get; set; }
    public int rol {get; set;}
}