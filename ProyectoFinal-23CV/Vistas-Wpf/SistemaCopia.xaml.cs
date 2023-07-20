using ProyectoFinal_23CV.Context;
using ProyectoFinal_23CV.Entities;
using ProyectoFinal_23CV.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly PeliculaService peliculaService = new PeliculaService();
        public SistemaCopia()
        {
            InitializeComponent();
            GetDatos();
        }


        public void GetDatos()
        {
            List<Genero> generos = new List<Genero>();
            using (var _context = new ApplicationDbContext())
            {
                generos = _context.Generos.ToList();
            }

            List<Pelicula> peliculas = this.peliculaService.GetAllPeliculas();
            MontarCombox(generos, peliculas);
        }

        private void MontarCombox(List<Genero> generos, List<Pelicula> peliculas)
        {
            SelectGenero.ItemsSource = generos;//.Select( s => s.PkGenero);
            SelectGenero.DisplayMemberPath = "Nombre";
            Peliculas.ItemsSource = peliculas;// ;.Select(s => s.PkGenero); ;
            Peliculas.DisplayMemberPath = "Titulo";
            SelectGenero.SelectedIndex = 0;
            Peliculas.SelectedIndex = 0;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Genero generoSelect = SelectGenero.SelectedValue as Genero;
            int genero = int.Parse(generoSelect.PkGenero.ToString());

            Pelicula peliculaSelect = Peliculas.SelectedValue as Pelicula;

            int peli = int.Parse(peliculaSelect.PkPelicula.ToString());
            
            Pelicula pelicula = this.peliculaService.GetPeliculaById(peli);

            //Genero gen = this.peliculaService.GetGenero(genero);

            Pelicula_Has_Genero nuevo = new Pelicula_Has_Genero()
            {
                GeneroId = genero,
                PeliculaId = pelicula.PkPelicula
            };

            Debugger.Break();

            pelicula.PeliculasGenero.Add(nuevo);

            this.peliculaService.UpdatePelicula(pelicula);

            MessageBox.Show("Genero agregado correctamente");

        }
    }
}
