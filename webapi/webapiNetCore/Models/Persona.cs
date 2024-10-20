
namespace webapi.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaNacimiento{get;set;}
    }
}
