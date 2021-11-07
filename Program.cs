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
        //              ++++++++++++++++++++++Delegados, Func y Action
        /**Con ( delegado ) podemos mandar funciones como parametros a otras funciones.
         * 
         */
        //public delegate string Mostrar(string cadena);

        static async Task Main(string[] args)
        {
            //============================FUNC
            //El ultimo argumento que se colaca es el tipo de dato que regresa, y antes de este podemos agregar hasta 16 tipos que puede recibir
            //Func<string, int> mostrar2 = Show;
            //con el codigo anterior, d ela linea 26, ya no tendremos que declarar nuestro delegado, podmeos comentar el delegado declarado en la linea 20
            //Todo(mostrar2);
            //y nos ahorramos el crear el tipos de delegados

            //===========================ACTION
            //Ahora el metodo NO RETORNA NADA solo ejecuta algo
            //Action<string, string> mostar = Show2;
            //          FUNCIONES ANONIMAS CON EXPRECIONES LAMDA Y USANDO LOS ACTION
            Action<string, string> mostar =
                (parametro1, parametro2) => Console.WriteLine(" CAFE " + " PAN");
            Todo(mostar);

            //===========================DELEGATE
            //Mostrar mostrar = Show;
            //Todo(mostrar);
        }

        public static void Todo(Action<string,string> funcionFinal)
        {
            Console.WriteLine("hago algo");
            //var retorno = funcionFinal("se invoca desde otra funcion");
            //Console.WriteLine(retorno);
            funcionFinal("se invoca desde otra funcion","La segunda cadna para le action");
            Console.WriteLine("Algo mas aparte");
        }

        //public static int  Show(string texto)
        //{
        //    return texto.Count();
        //}

        //public static void Show2(string cade1, string cad2)
        //{
        //    Console.WriteLine(cade1 + cad2);
        //}

    }
}
