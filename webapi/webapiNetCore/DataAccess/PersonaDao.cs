using Microsoft.Data.SqlClient;
using System.Data;
using webapi.Models;

namespace webapi.DataAccess
{
    public class PersonaDao
    {
        private readonly string _connectionString = @"Server=172.17.0.2;Database=PersonasBD;User Id=sa;Password=MSS-fernando-sql";

        public PersonaDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Persona persona)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Personas (DNI, Nombre, Fecha_Nacimiento) VALUES (@DNI, @Nombre, @Fecha_Nacimiento)", connection);
                command.Parameters.AddWithValue("@DNI", persona.DNI);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Fecha_Nacimiento", persona.FechaNacimiento);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Persona> GetAll()
        {
            var personas = new List<Persona>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Personas", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var persona = new Persona
                        {
                            Id = reader.GetInt32("Id"),
                            DNI = reader.GetInt32("DNI"),
                            Nombre = reader.GetString("Nombre"),
                            FechaNacimiento = reader.GetDateTime("Fecha_Nacimiento")
                        };
                        personas.Add(persona);
                    }
                }
            }

            return personas;
        }

         public Persona GetByDNI(int dni)
        {
            var personas = new List<Persona>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 * FROM Personas WHERE DNI=@DNI", connection);
                command.Parameters.AddWithValue("DNI", dni);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var persona = new Persona
                        {
                            Id = reader.GetInt32("Id"),
                            DNI = reader.GetInt32("DNI"),
                            Nombre = reader.GetString("Nombre"),
                            FechaNacimiento = reader.GetDateTime("Fecha_Nacimiento")
                        };
                        personas.Add(persona);
                    }
                }
            }

            if(personas.Count>0) 
                return personas[0];
            return null;
        }
    }
}
