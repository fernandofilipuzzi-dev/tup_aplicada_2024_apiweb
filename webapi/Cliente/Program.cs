using System;
using System.Collections.Generic;
using Cliente.Models;
using Cliente.Services;

namespace Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new PersonasServices().GetAll().Result;

            #region listando persoans
            foreach (Persona p in personas)
            {
                Console.WriteLine($"{p.DNI} - {p.Nombre}");
            }
            #endregion

            #region agregando una nueva persona
            Persona nueva =new PersonasServices().Save(new Persona { DNI = 23343243, Nombre = "Estefania" }).Result;
            if (nueva != null) Console.WriteLine($"{nueva?.DNI} - {nueva?.Nombre}");
            else Console.WriteLine(nueva);
            #endregion

            #region actualizando datos de una persona
            if (new PersonasServices().Update(new Persona { DNI = 23343243, Nombre = "Silvina" }).Result != null)
                Console.WriteLine("Actualizacion exitosa!");
            else 
                Console.WriteLine("Actualizacion no exitosa!");
            #endregion

            #region eliminando una persona
            if (new PersonasServices().Delete(dni: 23343243).Result == true)
                Console.WriteLine("Borrado exitoso!");
            else
                Console.WriteLine("Borrado no exitoso!");
            #endregion

            Console.ReadKey();
        }

    }
}
