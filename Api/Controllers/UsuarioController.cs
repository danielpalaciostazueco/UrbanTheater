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
        private readonly FileLogger _logger = new FileLogger("Log.Api.txt");


        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("{nombreUsuario}/Contrasena/{contrasena}")]
        public ActionResult<Usuario> GetUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                var usuario = _usuarioService.Get(nombreUsuario, contrasena);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                _logger.Log($"Get con nombre de usuario: {nombreUsuario} y contraseña: {contrasena} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public IActionResult AddUsuario([FromBody] Usuario usuarioRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioRequest.nombreUsuario) || string.IsNullOrWhiteSpace(usuarioRequest.contrasena))
                {
                    return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
                }

                _usuarioService.AddUsuario(usuarioRequest);
                return CreatedAtAction(nameof(GetUsuario), new { nombreUsuario = usuarioRequest.nombreUsuario, contrasena = usuarioRequest.contrasena }, usuarioRequest);

            }
            catch (Exception ex)
            {
                _logger.Log($"AddUsuario fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
