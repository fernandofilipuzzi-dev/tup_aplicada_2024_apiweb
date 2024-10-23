using System.Collections.Generic;
using System.Linq;
using webapi.Models;
using System.Web.Http;

namespace webapi.Controllers
{
    public class PersonasController : ApiController
    {
        static List<Persona> personas = new List<Persona> { new Persona { DNI = 2343243, Nombre = "Agustina" } };

        // GET: api/Personas
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(personas);
        }

        // GET: api/Personas/5
        [HttpGet]
        [Route("api/Personas/{dni}")]
        public IHttpActionResult Get(int dni)
        {
            var persona = personas.Where(p => p.DNI == dni).FirstOrDefault();
            return Ok(persona);
        }

        // POST: api/Personas
        [HttpPost]
        public IHttpActionResult Post([FromBody] Persona nueva)
        {
            var persona = personas.Where(p => p.DNI == nueva.DNI).FirstOrDefault();

            if (persona != null) return Conflict();

            personas.Add(nueva);
            return Ok(nueva);
        }

        // PUT: api/Personas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Personas/5
        public void Delete(int id)
        {
        }
    }
}
