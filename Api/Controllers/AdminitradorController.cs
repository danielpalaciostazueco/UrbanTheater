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

        public AdministradorController(AdministradorService administradorService)
        {
            _administradorService = administradorService;
        }


        [HttpGet("{nombreUsuario}/Contrasena/{contrasena}")]
        public ActionResult<Administrador> GetUsuario(string nombreUsuario, string contrasena)
        {
            var administrador = _administradorService.Get(nombreUsuario, contrasena);
            if (administrador == null)
            {
                return NotFound();
            }
            return Ok(administrador);
        }
    

    }
}