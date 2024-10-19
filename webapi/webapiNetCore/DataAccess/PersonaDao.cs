using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using webapi.Models;

namespace webapi.DataAccess
{
    public class PersonaDao
    {
       private readonly string _connectionString;

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
                            Apellido = reader.GetString(2)
                        };
                        personas.Add(persona);
                    }
                }
            }

            return personas;
        }
    }
}
