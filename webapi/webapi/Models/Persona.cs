



using System.Text.Json.Serialization;

namespace webapi.Models
{
    public class Persona
    {
        [JsonPropertyName("dni")]
        public int DNI { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }


}
