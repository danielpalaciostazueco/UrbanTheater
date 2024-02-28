using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System;

namespace UrbanTheater.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsientoController : ControllerBase
    {
        private readonly AsientoService _asientoService;

        public AsientoController(AsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        [HttpGet]
        public ActionResult<List<Asiento>> GetAll() => _asientoService.GetAll();
    }
}