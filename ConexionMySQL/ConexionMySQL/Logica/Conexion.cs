using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionMySQL.Entidades;
using MySql.Data.MySqlClient;


namespace ConexionMySQL.Logica
{
    class Conexion
    {
        private MySqlConnectionStringBuilder conexionBuilder;
        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader reader;

        public Conexion()
        {
            establecerParametrosConexion();
            conexion = new MySqlConnection(conexionBuilder.ToString());
        }

        private void establecerParametrosConexion()
        {
            conexionBuilder = new MySqlConnectionStringBuilder();
            conexionBuilder.Server = "localhost";       //La estamos haciendo en local
            conexionBuilder.UserID = "root";            //Nombre del usuario propietario de la base de datos
            conexionBuilder.Database = "monedero";      //Nombre de la base datos (donde se encuentran nuestras tablas)
            conexionBuilder.Password = "123456";        //Contraseña del usuario para acceder a la base de datos
        }

        internal Usuario buscarUsuario(string dniBuscar)
        {
            Usuario usuario;
            string consulta = "SELECT * FROM MONEDERO.usuario WHERE dni = ?dni";

            comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?dni", dniBuscar);

            conexion.Open();
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                usuario = new Usuario(reader["dni"].ToString(), reader["pager"].ToString(),
                                        reader["nombre"].ToString(), reader["apellido"].ToString());

                //Otra forma de obtener los datos:
                usuario = new Usuario(reader.GetString("dni"), reader.GetString("pager"), 
                                        reader.GetString("nombre"), reader.GetString("apellido"));
            }
            else
                usuario = null;

            conexion.Close();
            return usuario;
        }

        public string contarUsuariosBD()
        {
            StringBuilder resultadoSb = new StringBuilder();
            string consulta = "SELECT * FROM MONEDERO.usuario";
            comando = new MySqlCommand(consulta, conexion);

            conexion.Open();

            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                resultadoSb.Append(reader.GetString("dni")+" " + reader.GetString("pager")+ " " +
                                         reader.GetString("nombre") + " " + reader.GetString("apellido") +"\n");
            }

            conexion.Close();
            return resultadoSb.ToString();
        }

        internal void agregarUsuario(Usuario usuario)
        {
            String consulta = "INSERT INTO MONEDERO.usuario (dni, pager, nombre, apellido) VALUES" 
                +" (?dni, ?pager, ?nombre, ?apellido)";

            comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?dni", usuario.Dni);
            comando.Parameters.AddWithValue("?pager", usuario.Pager);
            comando.Parameters.AddWithValue("?nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("?apellido", usuario.Apellido);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
