using ProyectoFinal_23CV.Entities;
using ProyectoFinal_23CV.Services;
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
using System.Windows.Shapes;

namespace ProyectoFinal_23CV.Vistas_Wpf
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        UsuarioServices services = new UsuarioServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            if (txtPkUser.Text == "")
            {
               
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
                services.AddUser(usuario);

                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                MessageBox.Show("Se agrego correctamente");
                GetUserTable();
            }

            else
            {

                //tarea realizar la funcion Editar y eliminar

            }



        }

        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsers();
            
        }

        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }


        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario; //Esta funcion traera la selecion de la fila 

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();


        }




    }
}
