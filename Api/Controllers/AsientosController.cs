using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System;

namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsientosController : ControllerBase
    {
        private readonly AsientosService _asientosService;

        public AsientosController(AsientosService asientosService)
        {
            _asientosService = asientosService;
        }

        [HttpGet("{id}")]
        public ActionResult<Asientos> Get(string id)
        {
            var asientos = _asientosService.Get(id);
            if (asientos == null)
                return NotFound();
            return asientos;
        }

        [HttpPost("{idFecha}")]
        public ActionResult<Asientos> Post(string idFecha, [FromBody] string[] asientosOcupadosArray)
        {
            var asientos = new Asientos
            {
                idFecha = idFecha,
                AsientosOcupadosArray = asientosOcupadosArray
            };

            try
            {
                var createdAsiento = _asientosService.Add(asientos);
                return CreatedAtAction(nameof(Get), new { id = createdAsiento.idFecha }, createdAsiento);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
