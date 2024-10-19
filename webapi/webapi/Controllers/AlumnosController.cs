using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webapi.Models;

namespace webapi.Controllers
{
    public class AlumnosController : ApiController
    {
        static List<Persona> personas = new List<Persona> { new Persona { DNI = 2343243, Nombre = "Agustina" } };

        // GET: api/Alumnos
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(personas);
        }

        // GET: api/Alumnos/5
        [HttpGet]
        [Route("api/Alumnos/{dni}")]
        public IHttpActionResult Get(int dni)
        {
            var persona = personas.Where(p => p.DNI == dni).FirstOrDefault();
            return Ok(persona);
        }

        // POST: api/Alumnos
        [HttpPost]
        public IHttpActionResult Post([FromBody] Persona nueva)
        {
            var persona = personas.Where(p => p.DNI == nueva.DNI).FirstOrDefault();

            if (persona != null) return Conflict();

            personas.Add(nueva);
            return Ok(nueva);
        }

    }
}
