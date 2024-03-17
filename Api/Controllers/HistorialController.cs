using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System;
using Serilog;
namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistorialController : ControllerBase
    {
        private readonly HistorialService _historialService;



        public HistorialController(HistorialService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Historial>> Get(int id)
        {
            try
            {
                var historiales = _historialService.Get(id);
                if (historiales == null || !historiales.Any())
                {
                    return NotFound();
                }

                return historiales;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por nombre ");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] HistorialDTO historial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                foreach (var asiento in historial.asiento)
                {
                    _historialService.Add(historial.nombreUsuario, historial.nombreObra, historial.fecha, historial.sesion, asiento, historial.idUsuario);
                }


                return StatusCode(201, historial);
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Error al hacer el post");

                return StatusCode(500, "Error interno del servidor");
            }
        }

    }
}