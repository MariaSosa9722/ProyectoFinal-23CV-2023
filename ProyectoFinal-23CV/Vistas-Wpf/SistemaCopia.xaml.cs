using ProyectoFinal_23CV.Context;
using ProyectoFinal_23CV.Entities;
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
    /// Lógica de interacción para SistemaCopia.xaml
    /// </summary>
    public partial class SistemaCopia : Window
    {
        public SistemaCopia()
        {
            InitializeComponent();
            SelectGeneros();
        }



        public List<Genero> GetGeneros()
        {

            using (var _context = new ApplicationDbContext())
            {
                var response = _context.Generos.ToList();
                return response;

            }
        }

        private void SelectGeneros()
        {
            SelectGenero.ItemsSource = GetGeneros();
           
            SelectGenero.DisplayMemberPath = "Nombre";
           
                
        }
    }
}
