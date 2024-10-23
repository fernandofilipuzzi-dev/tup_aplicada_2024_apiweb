using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace webapi.Controllers
{
    public class FicherosController : ApiController
    {
       
        [HttpPost]
        [Route("api/Ficheros/upload")]
        async public Task<IHttpActionResult> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
                return Content(HttpStatusCode.UnsupportedMediaType, "Formato de datos no soportado");

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var content = provider.Contents.FirstOrDefault();
                var fs = await content.ReadAsStreamAsync();

                var fileName = content.Headers.ContentDisposition.FileName?.Trim('"');
                if (string.IsNullOrEmpty(fileName))
                    return BadRequest("El archivo no tiene un nombre válido");

                var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fs.CopyToAsync(stream);
                }

                return Ok(new { Message = "Archivo subido con éxito", fileName = fileName });

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
