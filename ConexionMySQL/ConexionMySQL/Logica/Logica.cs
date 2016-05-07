using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionMySQL.Entidades;

namespace ConexionMySQL.Logica
{
    class Logica
    {
        private MainWindow ventana;
        private Conexion conexion;

        public Logica(MainWindow ventanaEnt)
        {
            this.ventana = ventanaEnt;
            this.conexion = new Conexion();
        }

        public void agregarUsuarioBD(Usuario usuario)
        {
            conexion.agregarUsuario(usuario);
        }

        public bool buscarUsuarioBD(string dniBuscar)
        {
            bool encontrado = false;
            Usuario usuarioBuscado = conexion.buscarUsuario(dniBuscar);

            if(usuarioBuscado != null)
            {
                encontrado = true;
                ventana.tDni.Text = usuarioBuscado.Dni;
                ventana.tPager.Text = usuarioBuscado.Pager;
                ventana.tNombre.Text = usuarioBuscado.Nombre;
                ventana.tApellido.Text = usuarioBuscado.Apellido;
            }

            return encontrado;
        }

        public string contarUsuariosBD()
        {
            return conexion.contarUsuariosBD();
        }
    }
}
