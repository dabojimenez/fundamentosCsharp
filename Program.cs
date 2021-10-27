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
        //              ++++++++++++++++++++++GENERICS
        /**
         * 
         */
        static async Task Main(string[] args)
        {

            var cerveza = new Cerveza()
            {
                Alcohol = 5,
                cantidad = 30,
                Marca = "CERVEZA MIA",
                Nombre = "Cerveza mia"
            };

            var post = new Post()
            {
                correo = "david@coreeo.com",
                nombre = "davi",
                telefono = "123456789"
            };

            Service.SendRequest<Cerveza> service = new Service.SendRequest<Cerveza>();
            var cervezaRespuesta = await service.Send(cerveza);

            //  Enviamos la cnatidad de generecs solicitados
            //Service.SendRequest<Post, Cerveza, , ,> servicePost = new Service.SendRequest<Post>();
            //var postRespuesta = await servicePost.Send(post);


        }

    }
}
