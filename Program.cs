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
            ////                  =============      ++++METODO POST ( crear )
            //string url = "https://localhost:44376/api/personas";

            //var client = new HttpClient();

            //Post post = new Post()
            //{
            //    nombre = "PAVADA 2",
            //    telefono = "09000000",
            //    correo = "PAVADA2@correo.com"
            //};
            ////serializaremos este objeto creado de post, con las siguiente slineas d ecodigo
            //var data = JsonSerializer.Serialize<Post>(post);
            //HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            //var httpResponse = await client.PostAsync(url, content);

            ////var httpResponse = await client.GetAsync(url);

            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var result = await httpResponse.Content.ReadAsStringAsync();
            //    //Ahora lo deserealizamos para poder manipularlo con c#
            //    var postResult = JsonSerializer.Deserialize<Post>(result);

            //    //var content = await httpResponse.Content.ReadAsStringAsync();
            //    //List<Models.Post> posts = JsonSerializer.Deserialize<List<Models.Post>>(content);

            //}

            ////                  =============      ++++METODO PUT ( actualizar )
            //string urlPut = "https://localhost:44376/api/personas/2";

            //var client = new HttpClient();

            //Post postPut = new Post()
            //{
            //    id = 2,
            //    nombre = "put ID2",
            //    telefono = "0900Put",
            //    correo = "PUT id 2@correo.com"
            //};

            //var data = JsonSerializer.Serialize<Post>(postPut);
            //HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            //var httpResponse = await client.PutAsync(urlPut, content);

            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var result = await httpResponse.Content.ReadAsStringAsync();
            //    //var putResult = JsonSerializer.Deserialize<Post>(result);
            //}

            ////                  =============      ++++METODO DELETE ( eliminar )
            string urlDelete = "https://localhost:44376/api/personas/4";
            
            var cliente = new HttpClient();

            var httpResponse = await cliente.DeleteAsync(urlDelete);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync();
                var deletResult = JsonSerializer.Deserialize<Post>(result.Result.Trim());
            }


        }

    }
}
