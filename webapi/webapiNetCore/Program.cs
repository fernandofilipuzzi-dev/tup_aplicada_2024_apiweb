using Microsoft.OpenApi.Models;
using webapi.Controllers;
using webapiNetCore.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    //c.OperationFilter<FileUploadOperationFilter>();
});



//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });

//    //manejo de archivos
//    c.OperationFilter<FileUploadOperationFilter>(); // Asegúrate de agregar esto
//});

var app = builder.Build();

/*
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

*/
app.UseStaticFiles();
app.UseRouting();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    // agregado para poder acceder a swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger";//string.Empty; // deja a swagger disponible en la raiz
    });
}

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
