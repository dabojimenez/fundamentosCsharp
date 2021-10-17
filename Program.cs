using System;
using System.Collections.Generic;
using fundamentosCsharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace fundamentosCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //                          ====================ENTEROS POSITIVOS Y NEGATIVOS
            //Permite ingresar numeros negativos del -255 al 255
            byte numero = 255;

            int numeroInt = -12234;
            //Solo positivos
            uint numeroUint = 122345678;

            long numeroLong = -9876543;
            //Solo positivos
            ulong numeroUlong = 987654321234567;


            //      DECIMALES
            //Es de 4 bytes
            float numeroFloat = 190.1f;
            //Es de 8 bytes
            double numeroDouble = 113.2d;
            //Tiene mas alcance el decimal de 16 bytes
            decimal numeroDecimal = 1234.56m;

            //      CARCATERES
            //debemos usar comillas simples y solo un caracter
            char caracter = 'a';

            //      TIPOS DE DATOS COMPUESTOS
            string cadena = "hola mijo";
            //este tipo de datos represneta una clase y por lo q es un objeto
            DateTime date = DateTime.Now;

            bool siOno = false;

            int valor = new int();
            Console.WriteLine(valor.ToString());

            //Colocamos (?), lo hacemos nulable
            int? otherValue = null;

            //este tipo de dato no esta definido, hasta que la variable sea asignada, y lo asigna antes de la ejecucion y no puede ser un atributo, pero si en un metodo local
            //y una vez definido su tipo de dato ya no se podra cambiar, como el var de javascript
            var nombre = "david 34";

            var persona = new
            {
                nombre = "david",
                apellido = "jimenez"
            };
            Console.WriteLine(persona.nombre);

            //namespaces, es la declaracion de la coleccion que vamos a usar
            Bebida bebidad = new Bebida("coca cola", 2000);
            bebidad.Beberse(320);
            Console.WriteLine(bebidad.cantidad);

            //Cerveza cerveza = new Cerveza(30, "Brama");
            //cerveza.Beberse(1);
            //Console.WriteLine(cerveza.cantidad);

            //                          ====================ARREGLOS Y LISTAS
            int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            //for (int i=0; i < numeros.Length; i++)
            //{
            //    Console.WriteLine("Iteracion: "+i+" numero =>"+numeros[i]);
            //}

            foreach (var numeroFor in numeros)
            {
                //Console.WriteLine("Iteracion: " + i + " numero =>" + numeros[i]);
            }

            //                          ====================LISTA
            List<int> valores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };//Podemos agregarlo valores por defecto, sin limite
            valores.Add(9);
            valores.Add(0);
            valores.Remove(2);
            foreach (var unValor in valores)
            {
                Console.WriteLine("El item d ela lista es: " + unValor);
            }

            //                          ====================LISTA PERO AHORA DE CLASES
            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(506, "Club Premium") };
            cervezas.Add(new Cerveza(304));

            Cerveza brama = new Cerveza(500, "Mashomenos");
            cervezas.Add(brama);

            foreach (var unaCerveza in cervezas)
            {
                Console.WriteLine("Cervezas: " + unaCerveza.Nombre);
            }

            //          COLA
            //Queue<int>

            //                          ====================INTERFACES
            //Las interfaces son acciones o metodos que dicha clase debe cumplir de manera obligatoria
            //Si creamos una clase y le cmabiamos el nombre reservado ( class ), por ( interfaces ), debemos agregar la letra ( I ) antes del nombre de la clase
            //Por ejemplo:  interface IBebidaAlcoholica
            //Ahora si podemos agregar el nombre IBebidaAlcoholica, en cualquier otra clase y que deba cumplir dicha interfaz, por ejemplo:
            //  class Cerveza : Bebida, IBebidaAlcoholica
            //Con esto evitamos lo que es la mala escritura entre colaboradores al implementar una interfaz
            var bebidaVino = new Cerveza(120);
            Recomendacion(bebidaVino);

            CervezaBD cervezaBD = new CervezaBD();

            ////insertamos nueva cerveza
            //{ 
            //    Cerveza cerveza2 = new Cerveza(15,"CERVEZA DAVID");
            //    cerveza2.Marca = "LA MEJOR";
            //    cerveza2.Alcohol = 7;
            //    cervezaBD.Add(cerveza2);
            //}

            ////EDITAMOS nueva cerveza
            //{
            //    Cerveza cerveza2 = new Cerveza(789, "CERVEZA DAVID");
            //    cerveza2.Marca = " EDITADA";
            //    cerveza2.Alcohol = 789;
            //    cervezaBD.Edit(cerveza2, 5);
            //}

            ////ELIMINAMOS nueva cerveza
            //{
            //    cervezaBD.Delete(1002);
            //}
            ////Listar todas las cervezas
            //var cervezasBD = cervezaBD.Get();
            //foreach (var cer in cervezasBD)
            //{
            //    Console.WriteLine(cer.Nombre);
            //    Console.WriteLine(cer.Marca);
            //}
            //                          ====================Serialización de objetos y deserialización de JSON
            //Cerveza cerveza = new Cerveza(555, "CHEVECHA");
            ////Agregamos el siguiente namespace, para tranformar de Objeto a JSON: ( using System.Text.Json ) y ( using System.Text.Json.Serialization )
            ////PERO RECORDEMOS QUE SI TENEMOS UN CONSTRUCTOR QUE RECIVE DATOS EN NUESTRA CLASE MANTENDREMOS UN PEQUE;O INCONVENINETE, PARA ESTO
            ////DEBEMOS CREAR UN NUEVO CONSTRUCTO PERO VACIO, Y SI ES EL CADO, LE PASMAOS VALORES VACIOS O NULOS. ESTO EN NET 3.1
            //string miJson = JsonSerializer.Serialize(cerveza);
            ////Guardamos en un archivo nuestro Json, el ual recive dos parametros:
            ///**
            // * 1)   El nombre del archivo
            // * 2)   Recive el contenido, o el JSON
            // */
            //File.WriteAllText("miJson.txt",miJson);
            //  -----TRANSFORMAMOS DE Json a Objeto
            /**     El meotdo ( ReadAllText ),retorna un string y recibe un parametros:
             * 1)   El nombre del archivo o el PATH de donde se encuentra el archivo
             */
            string strJson = File.ReadAllText("miJson.txt");
            //dentro del generics ( <> ), indicamos al tipo de objeto que vamos a deserealizary dentro de los parnetecis colocamos nuestro json
            Cerveza cerveza = JsonSerializer.Deserialize<Cerveza>(strJson);




        }

        static void Recomendacion (IBebidaAlcoholica bebida)
        {
            bebida.MaximoRecomendado();
        }

    }
}
