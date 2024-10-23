using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace webapiNetCore.Models
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasFormFile = context.MethodInfo.GetParameters()
            .Any(p => p.ParameterType == typeof(IFormFile));

            if (hasFormFile)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "file",
                    In = ParameterLocation.Query,
                    Required = true,
                    Description = "Archivo a cargar",
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary"
                    }
                });
            }
        }
    }

}
