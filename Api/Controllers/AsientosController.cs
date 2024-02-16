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
    }
}