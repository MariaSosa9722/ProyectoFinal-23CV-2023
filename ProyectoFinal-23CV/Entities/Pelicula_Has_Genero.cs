using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_23CV.Entities
{
    public class Pelicula_Has_Genero
    {
       

        [ForeignKey("Pelicula")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
