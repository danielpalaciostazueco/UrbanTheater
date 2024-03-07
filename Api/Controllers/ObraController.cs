using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System.Collections.Generic;
using Serilog;

namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly ObraService _obraService;
 

        public ObraController(ObraService obraService)
        {
            _obraService = obraService;
        }

       [HttpGet]
        public ActionResult<List<Obra>> GetAll()
        {
             
                return _obraService.GetAll();
            
           
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
                Log.Error(ex, "Error al hacer el get por id "); 
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
                 Log.Error(ex, "Error el método de get por nombre "); 
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
                Log.Error(ex, "Error al obtener todas las obras"); 
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
                  Log.Error(ex, "Error al modificar la obra por id"); 
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
                Log.Error(ex, "Error al eliminar la obra por id"); 
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet("{id}/Session")]
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
                Log.Error(ex, "Error al obtener los asientos ocupados"); 
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost("{id}/Session")]
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
                 Log.Error(ex, "Error al añadir los asientos"); 
                return StatusCode(500, "Error interno del servidor");
            }

        }


    }
}
