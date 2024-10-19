using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using webapi.Models;

namespace webapi.DataAccess
{
    public class PersonaDao
    {
       private readonly string _connectionString=@"Server=172.17.0.2;Database=PersonasBD;User Id=sa;Password=MSS-fernando-sql;
";
        public PersonaDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Persona persona)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Personas (DNI, Nombre) VALUES (@DNI, @Nombre)", connection);
                command.Parameters.AddWithValue("@DNI", persona.DNI);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
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
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            DNI=reader.GetInt32(1)
                        };
                        personas.Add(persona);
                    }
                }
            }

            return personas;
        }
    }
}
