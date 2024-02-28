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
        private readonly FileLogger _logger = new FileLogger("Log.Api.txt");


        public AsientoController(AsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        [HttpGet]
        public ActionResult<List<Asiento>> GetAll()
        {
            try
            {
                return _asientoService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll fallado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}