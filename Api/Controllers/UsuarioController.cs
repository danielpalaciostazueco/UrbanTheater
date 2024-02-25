using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;

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

        // Ajusta la ruta si es necesario para adaptarse a tus estándares de API
        [HttpGet("{nombreUsuario}/Contrasena/{contrasena}")]
        public ActionResult<Usuario> GetUsuario(string nombreUsuario, string contrasena)
        {
            var usuario = _usuarioService.Get(nombreUsuario, contrasena);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AddUsuario([FromBody] Usuario usuarioRequest)
        {
            if (string.IsNullOrWhiteSpace(usuarioRequest.nombreUsuario) || string.IsNullOrWhiteSpace(usuarioRequest.contrasena))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            _usuarioService.AddUsuario(usuarioRequest);
            return CreatedAtAction(nameof(GetUsuario), new { nombreUsuario = usuarioRequest.nombreUsuario, contrasena = usuarioRequest.contrasena }, usuarioRequest);
        }
    }
}
