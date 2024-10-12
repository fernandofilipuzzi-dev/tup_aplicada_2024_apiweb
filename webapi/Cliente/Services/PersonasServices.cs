

using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Cliente.Models;
using System.Net;

namespace Cliente.Services
{
    public class PersonasServices
    {
        string url = "https://obscure-giggle-g4pgx9gj7jj29x7x-8080.app.github.dev/api/Personas";

        public async Task<List<Persona>> GetAll()
        {
            List<Persona> personas= new List < Persona >();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode == true)
                {
                    var objContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(objContent);
                    //[{"dni":2343243,"nombre":"Agustina"},{"dni":45645655,"nombre":"German"}]

                    personas = JsonSerializer.Deserialize<List<Persona>>(objContent);

                    return personas;
                }
            }
            return personas;
        }

        public async Task<Persona> GetPorDNI(int dni)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{url}/{dni}");

                if (response.IsSuccessStatusCode == true)
                {
                    var objContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(objContent);

                    return JsonSerializer.Deserialize<Persona>(objContent);
                }
            }
            return null;
        }

        public async Task<Persona> Save(Persona persona)
        {           
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent( JsonSerializer.Serialize(persona));

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode == true)
                {
                    var objContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(objContent);

                    return JsonSerializer.Deserialize<Persona>(objContent);
                }
            }
            return null;
        }

        public async Task<Persona> Update(Persona persona)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(persona));

                var response = await client.PutAsync($"{url}/{persona.DNI}", content);

                if (response.IsSuccessStatusCode == true)
                {
                    var objContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(objContent);

                    return JsonSerializer.Deserialize<Persona>(objContent);
                }
            }
            return null;
        }

        public async Task<bool> Delete(int dni)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{url}/{dni}");

                if (response.IsSuccessStatusCode == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
