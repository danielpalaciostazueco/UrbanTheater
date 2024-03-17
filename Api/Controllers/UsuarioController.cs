using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using Serilog; 
namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
    


        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }



        [HttpPost("Register")]
        public IActionResult AddUsuario([FromBody] Usuario usuarioRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioRequest.nombreUsuario) || string.IsNullOrWhiteSpace(usuarioRequest.contrasena))
                {
                    return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
                }
                var usuario = _usuarioService.Get(usuarioRequest.nombreUsuario, usuarioRequest.contrasena);
                if(usuario == null){
                   _usuarioService.AddUsuario(usuarioRequest); 
                    var usuario2 = _usuarioService.Get(usuarioRequest.nombreUsuario, usuarioRequest.contrasena);
                   return Ok(usuario2);
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el usuario."); 
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
