using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace fundamentosCsharp.Models
{
    class CervezaBD
    {
        //Cadena de conexion a una BD SQL Server
        //TIPO DE FORMA DE CONECCION A BASE DE DATOS ES TIPO ADO.NET DATA PROVIDER
        public string connectionString = "Data Source=DESKTOP-VKMHPOQ;Initial Catalog=BD_FUNDAMENTOS; User=test; Password=test12345";

        public List<Cerveza> Get()
        {
            List<Cerveza> cervezas = new List<Cerveza>();

            string query = "SELECT CZ_NOMBRE, CZ_MARCA, CZ_ALCOHOL, CZ_CANTIDAD FROM FD_CERVEZA";
            //El ( using ), sirve tanto para espeficiar los namespaces y tambien especificar todo lo que existe dentro de las llaves, existira solo aqui
            //y el obejto que se este creando muere al finalizar las llaves
            using(SqlConnection connection = new SqlConnection (connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                
                try
                {
                    connection.Open();
                    //Con ( SqlDataReader ) podemos leer el resultado de la consulta uno a uno
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int cantidad = reader.GetInt32(3);
                        string nombre = reader.GetString(0);
                        Cerveza cerveza = new Cerveza(cantidad, nombre);

                        cerveza.Alcohol = reader.GetInt32(2);
                        cerveza.Marca = reader.GetString(1);

                        //Agregamos al listado creado
                        cervezas.Add(cerveza);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            return cervezas;
        }

        public void Add(Cerveza cerveza)
        {
            //usamos el  carcater ( @ ) para enviar el valor, no lo hacmeos de manera ocncatenada [ cerveza.Nombre ], ya que no es buena practica por la INYECCION SQL
            string query = "INSERT INTO FD_CERVEZA (CZ_NOMBRE, CZ_MARCA, CZ_ALCOHOL, CZ_CANTIDAD) VALUES (@CZ_NOMBRE, @CZ_MARCA, @CZ_ALCOHOL, @CZ_CANTIDAD)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Ahora enviamos los parametros a la consulta de la siguiente manera
                command.Parameters.AddWithValue("@CZ_NOMBRE", cerveza.Nombre);
                command.Parameters.AddWithValue("@CZ_MARCA", cerveza.Marca);
                command.Parameters.AddWithValue("@CZ_ALCOHOL", cerveza.Alcohol);
                command.Parameters.AddWithValue("@CZ_CANTIDAD", cerveza.cantidad);
                //Abrimos la coneccion
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(Cerveza cerveza, int Id)
        {
            //usamos el  carcater ( @ ) para enviar el valor, no lo hacmeos de manera ocncatenada [ cerveza.Nombre ], ya que no es buena practica por la INYECCION SQL
            //string query = "INSERT INTO FD_CERVEZA ( , , ) VALUES (, , , )";
            string query = "UPDATE FD_CERVEZA SET CZ_NOMBRE=@CZ_NOMBRE, CZ_MARCA=@CZ_MARCA, CZ_ALCOHOL=@CZ_ALCOHOL, CZ_CANTIDAD=@CZ_CANTIDAD WHERE CZ_ID=@CZ_ID";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Ahora enviamos los parametros a la consulta de la siguiente manera
                command.Parameters.AddWithValue("@CZ_NOMBRE", cerveza.Nombre);
                command.Parameters.AddWithValue("@CZ_MARCA", cerveza.Marca);
                command.Parameters.AddWithValue("@CZ_ALCOHOL", cerveza.Alcohol);
                command.Parameters.AddWithValue("@CZ_CANTIDAD", cerveza.cantidad);
                command.Parameters.AddWithValue("@CZ_ID", Id);
                //Abrimos la coneccion
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int Id)
        {
            //usamos el  carcater ( @ ) para enviar el valor, no lo hacmeos de manera ocncatenada [ cerveza.Nombre ], ya que no es buena practica por la INYECCION SQL
            //string query = "UPDATE FD_CERVEZA SET CZ_NOMBRE=@CZ_NOMBRE, CZ_MARCA=@CZ_MARCA, CZ_ALCOHOL=@CZ_ALCOHOL, CZ_CANTIDAD=@CZ_CANTIDAD WHERE CZ_ID=@CZ_ID";
            string query = "DELETE FROM FD_CERVEZA WHERE CZ_ID=@CZ_ID";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Ahora enviamos los parametros a la consulta de la siguiente manera
                command.Parameters.AddWithValue("@CZ_ID", Id);
                //Abrimos la coneccion
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
