using Microsoft.AspNetCore.Mvc;
using UrbanTheater.Models;
using UrbanTheater.Business;
using System;
using Serilog;
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
        public ActionResult<List<Asiento>> GetAll()
        {
            try
            {
                return _asientoService.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al obtener los asientos por defecto"); 
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}