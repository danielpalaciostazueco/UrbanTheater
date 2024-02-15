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

        [HttpGet("GetAll")]
        public ActionResult<List<Asientos>> GetAll() => _asientosService.GetAll();
        [HttpGet("GetAllSeats")]
        public ActionResult<List<AsientosObras>> GetAllSeats() => _asientosService.GetAllSeats();

        [HttpGet("GetAllSeats/{id}")]
        public ActionResult<AsientosObras> GetAllSeatsId(int id)
        {
            var asiento = _asientosService.GetAllSeatsId(id);

            if (asiento == null)
                return NotFound();

            return asiento;
        }

        [HttpPost("UpsertSeats")]
        public IActionResult UpsertSeats([FromBody] AsientosDTO asientosDTO)
        {
            _asientosService.UpsertSeats(asientosDTO);
            return Ok();
        }



    }
}