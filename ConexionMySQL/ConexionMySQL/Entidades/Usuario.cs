using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionMySQL.Entidades
{
    class Usuario
    {
        //Los datos que vamos a usar de la base de datos son éstos:
        private string dni, pager, nombre, apellido;

        public Usuario(string dniEnt, string pagerEnt, string nombreEnt, string apellidoEnt)
        {
            this.Dni = dniEnt;
            this.Pager = pagerEnt;
            this.Nombre = nombreEnt;
            this.Apellido = apellidoEnt;
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }
             

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Pager
        {
            get
            {
                return pager;
            }

            set
            {
                pager = value;
            }
        }
    }
}
