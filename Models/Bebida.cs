using System;
using System.Collections.Generic;
using System.Text;

namespace fundamentosCsharp.Models
{
    class Bebida
    {
        //LOS dll, son paquetes compilados en c#, en las cuales se almacenan librerias, clases, y funciones encapsuladas
        
        public string Nombre { get; set; }
        public int cantidad { get; set; }

        public Bebida(string Nombre, int cantidad)
        {
            this.Nombre = Nombre;
            this.cantidad = cantidad;
        }

        public void Beberse( int cuantoBebio)
        {
            this.cantidad -= cuantoBebio;
        }
    }
}
