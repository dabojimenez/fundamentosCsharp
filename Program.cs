using System;
using System.Collections.Generic;
using fundamentosCsharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace fundamentosCsharp
{
    class Program
    {
        //              ++++++++++++++++++++++USO DE LINQ 2
        /**LINQ, e sun lengujae de ocnsulta
         * Para usarlo debemos agregar el ( using System.Linq )
         */
        static async Task Main(string[] args)
        {
            List<int> numeros = new List<int>()
            {
                7,1,6,123,546,7667,43,5234,67,53,13,65
            };

            /*
             * recibe un predicado y le ponemos elnombre q gustemos, segiudo de ( => ), este simbolo especifica lo que tiene q cumplir la expresion
             * la letra o nombre asigando, indica el concepto de la coleccion
             * con ( FirstOrDefault ), me regresa el valor por defecto, o el rimer valor encontrado
             */
            //funcion de busqueda por WHERE
            var numero7 = numeros.Where(n => n == 70).FirstOrDefault();
            //funcion de ordenar de manera descendente por OrderBy
            var numerosOrdenados = numeros.OrderBy(o => o);
            //funcion de sumado total por 
            var suma = numeros.Sum(s => s);
            //funcion Average, nos da el promedio


            foreach (var numero in numerosOrdenados)
            {
                Console.WriteLine("iteracion "+numero);
            }

            Console.WriteLine("buscqueda por where: "+numero7);

            Console.WriteLine("suma:  "+suma);

            List<Cerveza> cervezas = new List<Cerveza>()
            {
                new Cerveza(){ Alcohol = 10, cantidad = 100, Marca = "CERVECERIA NACIONAL", Nombre = "Club"},
                new Cerveza(){ Alcohol = 20, cantidad = 200, Marca = "CERVECERIA NACIONAL", Nombre = "Pilsener"},
                new Cerveza(){ Alcohol = 30, cantidad = 300, Marca = "CD S.A.", Nombre = "Cerveza Buena"},
                new Cerveza(){ Alcohol = 40, cantidad = 400, Marca = "CERVECERIA QUITO S.A", Nombre = "Chulla"}
            };

            ///*con la palabra recervada ( from ) comienzo la funcionalidad integrada de LINQ, depsues colocamos una palabra clave o letra, pero que sea descriptiva
            // * depsue scolocamos ( in ) y colocamos la coleccion q vaos a trabajar
            // */
            ////Hacemos una lista
            //var cervezasOrdenadas = from c in cervezas
            //                        where c.Marca == "CD S.A." && c.Nombre == "Cerveza Vieja"//usmaos un where
            //                        orderby c.Marca //Ordenate por elcampo Marca
            //                        select c;//Seleccioname todo el conjunto
            //foreach (var orden in cervezasOrdenadas)
            //{
            //    Console.WriteLine($"{orden.Nombre} y su marca {orden.Marca}");
            //}

            /*EN el segundo video de LINQ 2 crearemos una lista de la clase bare
             */
            List<Bar> bares = new List<Bar>()
            {
                new Bar("El bar")
                {
                    cervezas = new List<Cerveza>(cervezas)
                },
                new Bar("DaviB")
                {
                    cervezas = new List<Cerveza>()
                    {
                        new Cerveza(){ Alcohol = 70, cantidad = 300, Marca = "Ecuatoriano", Nombre = "Cerveza Bien"},
                        new Cerveza(){ Alcohol = 80, cantidad = 400, Marca = "Quiteno", Nombre = "ChullaVida"},
                        new Cerveza(){ Alcohol = 80, cantidad = 400, Marca = "Quiteno", Nombre = "Pilsener"}
                    }
                },
                new Bar("Bar nuevo")
            };

            //Uso de LINQ
            var bar = (from b in bares
                      where b.cervezas.Where(c => c.Nombre == "Pilsener").Count() > 0
                      select new BarData(b.Nombre)
                      {
                          //sub consulta interna como en SQL
                         bebidas = (from c in b.cervezas
                                    select new Bebida(c.Nombre, c.cantidad)
                                    //Agregamos mas atributos que no estan dnetro del cosntructor de la siguiente manera, siempre y cuando tenga dicha clase dicho atributo
                                    {
                                        al = c.Alcohol
                                    }
                                    ).ToList()
                      }
                      ).ToList();


        }

    }
}
