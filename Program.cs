using System;
using System.Collections.Generic;
using fundamentosCsharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using fundamentosCsharp.Errors;

namespace fundamentosCsharp
{
    class Program
    {
        //              ++++++++++++++++++++++Control de situaciones inesperadas con Excepciones
        /**Con ( using ) creamos un objeto y manda la funcion dispouse por defecto, liberando asi el objeto
         * 
         */
        static async Task Main(string[] args)
        {
            //try
            //{
            //    using (var archivo = new StreamWriter(@"C:\hola.txt"))
            //    {
            //        archivo.WriteLine("Q ola");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Service.SearcherBeer buscarCerveza = new Service.SearcherBeer();

            try
            {
                var obtenerCantidad = buscarCerveza.GetCantidad("JustaNOHAY");
                Console.WriteLine("Si encontro");
            }
            catch ( FieldAccessException ex)
            {
                Console.WriteLine("Cache el Fiel Exception, "+ex);
            }
            //Cachamos una operacion invalida con ( InvalidOperationException )
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ha caido en una operaicon invalida, "+ex.Message);
            }
            //Cachamos nuestro error
            catch (CervezaNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Exepcion general
            catch (Exception ex)
            {
                Console.WriteLine("Algo no epserado");
            }
            
            // Con ( finally ), siempre se va a ejecutar, ya que si algun archivo a caido en el ( catch ) ese archivo ya no se va a poder abrir
            finally
            {
                Console.WriteLine("Siempre se ejecuta");
            }

        }

    }
}
