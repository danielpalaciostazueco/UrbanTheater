using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System.Collections.Generic;

namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly ObraService _obraService;
        private readonly FileLogger _logger = new FileLogger("Log.Api.txt");

        public ObraController(ObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpGet]
        public ActionResult<List<Obra>> GetAll()
        {
            try
            {
                return _obraService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Obra> Get(int id)
        {
            try
            {
                var obra = _obraService.Get(id);
                if (obra == null)
                {
                    return NotFound();
                }

                return obra;
            }
            catch (Exception ex)
            {
                _logger.Log($"Get con ID: {id} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("/Obras/Nombre/{name}")]
        public ActionResult<Obra> GetByName(string name)
        {
            try
            {
                var obra = _obraService.GetByName(name);
                if (obra == null)
                {
                    return NotFound();
                }

                return obra;
            }
            catch (Exception ex)
            {
                _logger.Log($"GetByName con name: {name} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public ActionResult<Obra> Create(Obra obra)
        {
            try
            {
                if (_obraService.Get(obra.ObraID) != null)
                {
                    return BadRequest($"Obra con ID {obra.ObraID} ya existe.");
                }

                _obraService.Add(obra);
                return CreatedAtAction(nameof(Create), new { id = obra.ObraID }, obra);
            }
            catch (Exception ex)
            {
                _logger.Log($"Create fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Obra obra)
        {
            try
            {
                if (id != obra.ObraID)
                {
                    return BadRequest();
                }

                var existingObra = _obraService.Get(id);
                if (existingObra == null)
                {
                    return NotFound();
                }

                _obraService.Update(obra);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Log($"Update con ID: {id} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obra = _obraService.Get(id);
                if (obra == null)
                {
                    return NotFound();
                }

                _obraService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Log($"Delete con ID: {id} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet("{id}/Session/{sessionId}/Seats")]
        public ActionResult<ReservaAsientoDTO> GetSeat(int id, int sessionId)
        {
            try
            {

                var asientosId = _obraService.GetObrasAsientos(id, sessionId);

                if (asientosId == null)
                {
                    return NotFound("No se ha encontrado la obra.");
                }

                return Ok(asientosId);
            }
            catch (Exception ex)
            {
                _logger.Log($"GetSeat con ID: {id} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost("{id}/Session/{sessionId}/Seats")]
        public IActionResult AddAsientosToSession(int id, int sessionId, [FromBody] ReservaAsientoDTO asientoRequests)
        {
            try
            {
                if (asientoRequests == null)
                {
                    return BadRequest("No hay información de asiento para agregar.");
                }

                foreach (var asientoRequest in asientoRequests.asientos)
                {
                    _obraService.AddAsientoToObra(id, sessionId, asientoRequest);
                }

                return Ok("Asientos añadidos correctamente.");

            }
            catch (Exception ex)
            {
                _logger.Log($"AddAsientosToSession con ID: {id} fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }

        }


    }
}
