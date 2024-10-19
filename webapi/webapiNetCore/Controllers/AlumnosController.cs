using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        static List<Persona> personas = new List<Persona> { new Persona { DNI = 2343243, Nombre = "Agustina" } , new Persona { DNI = 43234245, Nombre = "Cesar" } };

        // GET: api/<AlumnosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personas);
        }



      
    }
}
