using fundamentosCsharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace fundamentosCsharp.Service
{
    //La letra ( T ) indica que va a recibir una clase, que definira el objeto con el que trabajara
    //usmaos ( where ) para ligar  a una interfaces
    //Ademas podemos agregar la cnatidad de generis que nosoros deseamos usar y poder filtar o definirlas por un where
    public class SendRequest<T, U, M, X> where T : IRequesTable
        where U : IBebidaAlcoholica
    {

        HttpClient _client = new HttpClient();

        public async Task<T> Send(T model)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            var data = JsonSerializer.Serialize<T>(model);

            HttpContent content =
                new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                var postResult = JsonSerializer.Deserialize<T>(result);
                return postResult;
            }

            
            return default(T);

        }
    }
}
