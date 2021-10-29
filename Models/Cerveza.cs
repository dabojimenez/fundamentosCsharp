using System;
using System.Collections.Generic;
using System.Text;

namespace fundamentosCsharp.Models
{
    public class Cerveza : Bebida, IBebidaAlcoholica, IRequesTable
    {
        public int id { get; set; }
        public int Alcohol { get; set; }
        public string Marca { get; set; }

        public void MaximoRecomendado()
        {
            Console.WriteLine("El maximo permitido es 10 botellas");
        }

        public Cerveza() : base(null, 0)
        {

        }

        public Cerveza(int Cantidad, string Nombre = "Pilsener") : base(Nombre, Cantidad)
        {

        }
    }
}