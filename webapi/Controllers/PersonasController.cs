﻿using Microsoft.AspNetCore.Mvc;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        static List<Persona> personas = new List<Persona> { new Persona { DNI = 2343243, Nombre = "Agustina" } };

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personas);
        }

        // GET api/<PersonasController>/5
        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            var p= personas.Where(p=>p.DNI==dni).FirstOrDefault();
            return Ok(p);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona nueva)
        {
            var p = personas.Where(p => p.DNI == nueva.DNI).FirstOrDefault();

            if(p!=null) return Conflict(p);

            personas.Add(nueva);
            return Ok(nueva);
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{dni}")]
        public IActionResult Put(int dni, [FromBody] Persona persona)
        {
            var p = personas.Where(p => p.DNI == persona.DNI).FirstOrDefault();

            if (p == null) return NotFound(persona);

            p.DNI = persona.DNI;
            p.Nombre = persona.Nombre;

            return Ok(p);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
