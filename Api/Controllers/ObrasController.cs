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
        public ActionResult<List<Obras>> GetAll() => _obraService.GetAll();

        // GET: /Obras/{id}
        [HttpGet("{id}")]
        public ActionResult<Obras> Get(int id)
        {
            var obra = _obraService.Get(id);

            if (obra == null)
                return NotFound();

            return obra;
        }

        // PUT: /Obras/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Obras obra)
        {
            if (id != obra.ObraID)
                return BadRequest();

            var existingObra = _obraService.Get(id);
            if (existingObra is null)
                return NotFound();

            _obraService.Update(obra);

            return NoContent();
        }

        [HttpPost]//Post Datos Obras

        public ActionResult<Obras> Create(Obras obra)
        {
            _obraService.Add(obra);

            return CreatedAtAction(nameof(Create), new { id = obra.ObraID }, obra);
        }

        //-------Asientos-------------------------//


        [HttpGet("{obraId}/Session/{sessionId}/Seat")]//Método para obtener los asientos de una obra
        public ActionResult<AsientosDTO> GetSeat(int obraId, int sessionId)
        {
            var obraAsientos = _obraService.GetObrasAsientos(obraId, sessionId);//hecho este paso

            if (obraAsientos == null)
            {
                return NotFound("Obra not found.");
            }


            var sessionAsientos = obraAsientos.IdAsiento;
            List<int> asientos = new List<int>();
            asientos.Add(sessionAsientos);
            var resultado = new AsientosDTO { asientos = asientos };

            return Ok(resultado);
        }

        [HttpPost("{obraId}/Session/{sessionId}/AddAsientos")]


        public IActionResult AddAsientosToSession(int obraId, int sessionId, [FromBody] AsientoRequest asientoRequest)
        {
            // Obtener todos los asientos existentes para la obra y la sesión especificadas.
            var obraAsientosExistentes = _obraService.GetObrasAsientos(obraId, sessionId);

            if (obraAsientosExistentes == null)
            {
                _obraService.PostObrasAsientos(new ObrasDTO
                {
                    IdObra = obraId,
                    IdSesion = sessionId,
                    IdAsiento = asientoRequest.AsientoId,
                    IsFree = asientoRequest.IsFree
                });
            }
            else
            {
                _obraService.PostObrasAsientos(obraAsientosExistentes);

            }
            return Ok("Asientos added successfully.");
        }
    }
}
