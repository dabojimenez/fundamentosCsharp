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
    static class Program
    {
        //              ++++++++++++++++++++++Predicate
        /**Es la implementaciond e los delegados
         * Es una sentencia que regresa VERDAD o FALSO, es algo logico, nos pemrite guardar la logica
         * 
         */
        //public delegate string Mostrar(string cadena);

        static void Main(string[] args)
        {
            var numeros = new List<int> { 1, 2, 3456, 54321, 234567, 8, 76, 3, 45 };

            //Creacion d eun predicado
            var predicado = new Predicate<int>(x => x % 2 == 0);
            //negacion d eun predicado
            Predicate<int> negativePredicate = x => !predicado(x);

            var dividers2 = numeros.FindAll(negativePredicate);

            dividers2.ForEach(d => { Console.WriteLine(d); });

            //          USANDO UNA CLASE
            Console.WriteLine("USO DE PREDICADOS CON UNA CLASE LLAMADA CERVEZA");
            Console.WriteLine("");
            var listCerveza = new List<Cerveza> {
                new Cerveza(){Alcohol=10, Marca="CN. S.A", Nombre="David"},
                new Cerveza(){Alcohol=30, Marca="CERVEZA. S.A", Nombre="DavidC"},
                new Cerveza(){Alcohol=50, Marca="NOVEDAD. S.A", Nombre="DavidJS"},
                new Cerveza(){Alcohol=60, Marca="CN. S.A", Nombre="David12"},
            };
            var listCerveza2 = new List<Cerveza> {
                new Cerveza(){Alcohol=5, Marca="CN. S.A", Nombre="Cerveza 5"},
                new Cerveza(){Alcohol=100, Marca="CERVEZA. S.A", Nombre="cerveza 100"},
                new Cerveza(){Alcohol=22, Marca="NOVEDAD. S.A", Nombre="Cerce 22"},
                new Cerveza(){Alcohol=6, Marca="CN. S.A", Nombre="la de 6"},
            };

            listCerveza.ShowCervezaVeryHeavy(x => (x.Alcohol >= 15 && x.Alcohol < 100));
            listCerveza2.ShowCervezaVeryHeavy( x => (x.Alcohol >= 15 && x.Alcohol <100));

        }

        static bool IsDEvisible2(int x) => x % 2 == 0;

        static void ShowCervezaVeryHeavy(this List<Cerveza> listCerveza, Predicate<Cerveza> condicion)
        {
            var evilCerceza = listCerveza.FindAll(condicion);
            evilCerceza.ForEach(c => Console.WriteLine(c.Nombre));
        }

    }
}
