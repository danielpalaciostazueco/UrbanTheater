using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System.Collections.Generic;

namespace TetePizza.Controllers
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

        // GET: /Obras
        [HttpGet]
        public ActionResult<List<Obra>> GetAll() => _obraService.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Obra> Get(int id)
        {
            var obra = _obraService.Get(id);

            if (obra == null)
                return NotFound();

            return obra;
        }


        [HttpGet("/Obras/Nombre/{name}")]
        public ActionResult<Obra> Get(string name)
        {
            var obra = _obraService.GetByName(name);

            if (obra == null)
                return NotFound();

            return obra;
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Obra obra)
        {
            if (id != obra.ObraID)
                return BadRequest();

            var existingObra = _obraService.Get(id);
            if (existingObra is null)
                return NotFound();

            _obraService.Update(obra);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Obra> Create(Obra obra)
        {
            var existeObra = _obraService.Get(obra.ObraID);
            if (existeObra != null)
            {
                return BadRequest($"Una obra con el ID {obra.ObraID} ya existe.");
            }

            _obraService.Add(obra);
            return CreatedAtAction(nameof(Create), new { id = obra.ObraID }, obra);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obra = _obraService.Get(id);

            if (obra is null)
                return NotFound();

            _obraService.Delete(id);

            return NoContent();
        }


        [HttpGet("{id}/Session/{sessionId}/Seats")]
        public ActionResult<ReservaAsientoDTO> GetSeat(int id, int sessionId)
        {
            var asientosId = _obraService.GetObrasAsientos(id, sessionId);

            if (asientosId == null )
            {
                return NotFound("No se ha encontrado la obra.");
            }

            return Ok(asientosId);
        }


        [HttpPost("{id}/Session/{sessionId}/Seats")]
        public IActionResult AddAsientosToSession(int id, int sessionId, [FromBody] ReservaAsientoDTO asientoRequests)
        {
            if (asientoRequests == null )
            {
                return BadRequest("No hay información de asiento para agregar.");
            }

            foreach (var asientoRequest in asientoRequests.asientos)
            {
                _obraService.AddAsientoToObra(id, sessionId, asientoRequest);
            }

            return Ok("Asientos añadidos correctamente.");
        }


    }
}
