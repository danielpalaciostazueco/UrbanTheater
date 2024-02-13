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

        [HttpPost]

        public ActionResult<Obras> Create(Obras obra)
        {
            _obraService.Add(obra);

            return CreatedAtAction(nameof(Create), new { id = obra.ObraID }, obra);
        }
    }
}
