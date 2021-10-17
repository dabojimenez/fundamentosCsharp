using System;
using System.Collections.Generic;
using System.Text;

namespace fundamentosCsharp.Models
{
    class Vino : Bebida, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }

        public void MaximoRecomendado()
        {
            Console.WriteLine("El maximo permitido es 3 copas");
        }

        public Vino(int Cantidad, string Nombre = "VinoLindo") : base(Nombre, Cantidad)
        {

        }
    }
}
