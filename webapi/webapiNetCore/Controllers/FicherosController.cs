using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicherosController : ControllerBase
    {
        //dotnet add package Swashbuckle.AspNetCore
        //dotnet add package Microsoft.AspNetCore.Http
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("upload")]
        async public Task<IActionResult> UploadFile( IFormFile file)
        {
            
            if (file == null || file.Length == 0)
                return BadRequest("No se seleccionó ningún fichero");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { Message = "Archivo subido con éxito", fileName = file.Name });
           
        }

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

            if (!System.IO.File.Exists(path))
                return NotFound("El archivo no fue encontrado");

            var fileBytes = System.IO.File.ReadAllBytes(path);
            var contentType = "application/octet-stream"; // Cambia el tipo de contenido si es necesario
            return File(fileBytes, contentType, fileName);
        }
    }
}
