using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System;

namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorService _administradorService;
        private readonly FileLogger _logger = new FileLogger("Log.Api.txt");

        public AdministradorController(AdministradorService administradorService)
        {
            _administradorService = administradorService;
        }


        [HttpGet("{nombreUsuario}/Contrasena/{contrasena}")]
        public ActionResult<Administrador> GetUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                var administrador = _administradorService.Get(nombreUsuario, contrasena);
                if (administrador == null)
                {
                    return NotFound();
                }
                return Ok(administrador);

            }
            catch (Exception ex)
            {
                _logger.Log($"GetUsuario fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


    }
}