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
