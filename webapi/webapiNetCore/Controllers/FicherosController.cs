using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicherosController : ControllerBase
    {
        /*
        [HttpPost("upload")]
        async public Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if(file==null || file.Length==0)
                return BadRequest("No se seleccionó ningún fichero");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok( new {Message="Archivo subido con éxito", fileName=file.Name} );
        }
*/
    }
}
