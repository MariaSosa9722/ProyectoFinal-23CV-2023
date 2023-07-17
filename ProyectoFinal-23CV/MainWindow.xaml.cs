using ProyectoFinal_23CV.Services;
using ProyectoFinal_23CV.Vistas_Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal_23CV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        UsuarioServices services = new UsuarioServices();
        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string user = txtUserName.Text;
            string password = txtPassword.Text;

            var response = services.Login(user, password);

            if (response.Roles.Nombre == "sa")
            {
                Sistema sistema = new Sistema();
                Close();
                sistema.Show();
            }
            else
            {
                SistemaCopia sistemaCopia = new SistemaCopia();
                Close();
                sistemaCopia.Show();
            }
      
        }
    }
}
