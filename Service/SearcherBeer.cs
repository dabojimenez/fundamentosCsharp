using fundamentosCsharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using fundamentosCsharp.Errors;

namespace fundamentosCsharp.Service
{
    public class SearcherBeer
    {
        public List<Cerveza> cervezas = new List<Cerveza>()
        {
            new Cerveza(){Alcohol = 10, cantidad = 50, Marca="Nacional", Nombre="Pilsener"},
            new Cerveza(){Alcohol = 20, cantidad = 60, Marca="Patria", Nombre="Justa"},
            new Cerveza(){Alcohol = 30, cantidad = 70, Marca="Quito", Nombre="quitoBeer"},
        };

        public int GetCantidad(string Nombre)
        {
            var cerveza = (from c in cervezas
                           where c.Nombre == Nombre
                           //( First ), debe estar todo correcto de lo contrario no retornara ni siquiera null y se tronara la ejecucion ya q estara esperando el primer elento devuelto
                           //( FirstOrDefault ), devuelve un null en caso d eque la sentencia no devuelva o no encuentre algo
                           select c).FirstOrDefault();
            ////Exepcion en ( FieldAccessException )
            //throw new FileNotFoundException("Hola no me cacho");
            //Una vez creada nuetsra propia exception podemos usarla de la siguiente manera
            if (cerveza == null)
            {
                //lanzamos nuestra excepcion
                throw new CervezaNotFoundException("La cerveza se ha temrinado");
            }
            return cerveza.cantidad;
        }
    }
}
