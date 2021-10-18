using System;
using System.Collections.Generic;
using fundamentosCsharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace fundamentosCsharp
{
    class Program
    {
        //              ++++++++++++++++++++++PROGRAMACION ASINCRONA
        /**
         * Agregamos la palabra ( asyn ) y ( Task ), con su namespace ( using System.Threading.Tasks )
         */
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            //Realizamos la conexion con ( HttpClient ) con su namespace ( using System.Net.Http )
            HttpClient cliente = new HttpClient();
            /**
            //Hacemos la solicitud con ( GetAsync )
            var repsuesta = cliente.GetAsync(url);
            Console.WriteLine("COMI ALGO");
            //con ( await ) sercioramos que ya se ha terminado o espera hasta q termine, nos ayuda  acerciorar de que hasta que no temrine su tarea del hilo creado, no seguira con el codigo siguiente
            await repsuesta;

            Console.WriteLine("BEBIENDO CERVEZA");
            */

            //Ahora con este codigo necesitamos la repsuesta de manera inmediata, y qu eno avance al siguiente codigo hasta que llegue
            var httpResponse = await cliente.GetAsync(url);
            //Evaluamos la repsuesata si ha sido correcta con el atributo ( IsSuccessStatusCode ), lo que regresa un codigo 200 si es exitoso
            if (httpResponse.IsSuccessStatusCode)
            {
                /**Nos regresa una lista de Post
                 * Con ( ReadAsStringAsync ), nos regresa el contenido del body, el cupero en si 
                */
                var content = await httpResponse.Content.ReadAsStringAsync();
                List<Models.Post> posts =
                    JsonSerializer.Deserialize<List<Models.Post>>(content);

            }


        }

    }
}
