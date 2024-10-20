using Microsoft.AspNetCore.Mvc;

using webapi.Models;
using webapi.DataAccess;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaDao _personaDao;

        public PersonasController()
        {
            _personaDao = new PersonaDao(@"Server=172.17.0.2;Database=PersonasBD;User Id=sa;Password=MSS-fernando-sql;Trusted_Connection=True;TrustServerCertificate=True;");
           // _personaDao = new PersonaDao(@"Server=TSP;Database=prueba2;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;");
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            var personas = _personaDao.GetAll();
            return Ok(personas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            _personaDao.Add(persona);
            return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
        }
    }
}
