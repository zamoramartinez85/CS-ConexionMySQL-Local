using ConexionMySQL.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConexionMySQL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logica.Logica logica;
        public MainWindow()
        {
            InitializeComponent();
            logica = new Logica.Logica(this);

        }

        private void bAgregar_Click(object sender, RoutedEventArgs e)
        {
            string dni = tDni.Text;
            string pager = tPager.Text;
            string nombre = tNombre.Text;
            string apellido = tApellido.Text;

            Usuario usuario = new Usuario(dni, pager, nombre, apellido);

            logica.agregarUsuarioBD(usuario);
        }

        private void bBuscar_Click(object sender, RoutedEventArgs e)
        {
            string dniBuscar = tDniBuscar.Text;
            bool encontrado = logica.buscarUsuarioBD(dniBuscar);

            if (!encontrado)
                MessageBox.Show("No hay nadie con ese DNI");
            else
                MessageBox.Show("Usuario encontrado");            
        }

        private void bContar_Click(object sender, RoutedEventArgs e)
        {
            string usuarios = logica.contarUsuariosBD();

            MessageBox.Show(usuarios);
        }
    }
}
