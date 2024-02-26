using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System.Collections.Generic;

namespace TetePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ObrasController : ControllerBase
    {
        private readonly ObrasService _obraService;

        public ObrasController(ObrasService obraService)
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


        [HttpGet("{id}/Session/{sessionId}/Seat")]
        public ActionResult<List<AsientoDTO>> GetSeat(int id, int sessionId)
        {
            var asientosId = _obraService.GetObrasAsientos(id, sessionId);

            if (asientosId == null || asientosId.Count == 0)
            {
                return NotFound("No se ha encontrado la obra.");
            }

            return Ok(asientosId);
        }


        [HttpPost("{id}/Session/{sessionId}/AddAsientos")]
        public IActionResult AddAsientosToSession(int id, int sessionId, [FromBody] List<Asiento> asientoRequests)
        {
            if (asientoRequests == null || asientoRequests.Count == 0)
            {
                return BadRequest("No hay información de asiento para agregar.");
            }

            foreach (var asientoRequest in asientoRequests)
            {
                _obraService.AddAsientoToObra(id, sessionId, asientoRequest.idAsiento, asientoRequest.isFree);
            }

            return Ok("Asientos añadidos correctamente.");
        }


    }
}
