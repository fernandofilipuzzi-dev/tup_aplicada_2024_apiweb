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

// GET api/<PersonasController>/5
        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            try
            {
                var p= personas.Where(p=>p.DNI==dni).FirstOrDefault();

                if(p!=null)
                return Ok(p);
                else
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);  
            }
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona nueva)
        {
            try
            {
                var p = personas.Where(p => p.DNI == nueva.DNI).FirstOrDefault();

                if(p!=null) return Conflict(p);

                personas.Add(nueva);
                return Ok(nueva);
            }
            catch(Exception ex)
            {
                return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);  
            }
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{dni}")]
        public IActionResult Put(int dni, [FromBody] Persona persona)
        {
            try
            {
                var p = personas.Where(p => p.DNI == persona.DNI).FirstOrDefault();

                if (p == null) 
                    return NotFound(persona);

                p.DNI = persona.DNI;
                p.Nombre = persona.Nombre;

                return Ok(p);
            }
            catch(Exception ex)
            {
                return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);  
            }
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{dni}")]
        public IActionResult Delete(int dni)
        {
            try
            {
                var p = personas.Where(p => p.DNI == dni).FirstOrDefault();

                if (p == null) return NotFound();

                personas.Remove(p);

                return Ok();
            }
            catch(Exception ex)
            {
                return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);
            }
        }
    }
}
