using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23CV.Entities
{
    public class Genero
    {
        public Genero()
        {
            PeliculasGenero = new List<Pelicula_Has_Genero>();
        }
        [Key]
        public int PkGenero { get; set; }
        public string Nombre { get; set; }
        public List<Pelicula> Peliculas { get; set; }
        public ICollection<Pelicula_Has_Genero> PeliculasGenero { get; set; }

    }
}
