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
            // _personaDao = new PersonaDao(@"Server=172.17.0.2;Database=PersonasBD;User Id=SA;Password=MSS-fernando-sql;Trusted_Connection=True;Encrypt=False;");
           // _personaDao = new PersonaDao(@"Server=172.17.0.2,1433;Initial Catalog=Mydatabse;User Id=SA;Password=MSS-fernando-sql;Persist Security Info=False;Trusted_Connection=False;Encrypt=False;TrustServerCertificate=True;");
           // _personaDao = new PersonaDao(@"Server=172.17.0.2;Database=PersonasBD;User Id=SA;Password=MSS-fernando-sql;Trusted_Connection=True;Encrypt=False;");
            //_personaDao = new PersonaDao(@"Server=172.17.0.2;Database=PersonasBD,1433;User Id=SA;Password=MSS-fernando-sql;TrustServerCertificate=True;Trusted_Connection=True;Encrypt=False;");

             //funciono
             //_personaDao = new PersonaDao(@"Server=TSP;Database=prueba2;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;");
             //_personaDao = new PersonaDao(@"Server=PersonasDB.mssql.somee.com;Database=PersonasDB;User Id=fernando-utn_SQLLogin_1;Password=j3zdsvlw4z;TrustServerCertificate=True;");
             _personaDao = new PersonaDao(@"Server=172.17.0.2;Database=PersonasDB;User Id=sa;Password=MSS-fernando-sql;TrustServerCertificate=True;"); 
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var personas = _personaDao.GetAll();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, new { message = "Ocurrió un error al obtener las personas.", error = ex.Message+"|"+ ex.StackTrace});
                return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);
            }
        }

        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            try
            {
                Persona p=_personaDao.GetByDNI(dni);

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

        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            try
            {
                _personaDao.Add(persona);
                return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
            }
            catch(Exception ex)
            {
                 return Problem( "Ocurrió un error al obtener las personas.", ex.Message+"|"+ ex.StackTrace);
            }
        }
    }
}
