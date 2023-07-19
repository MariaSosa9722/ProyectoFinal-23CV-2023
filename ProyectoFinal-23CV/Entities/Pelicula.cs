using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23CV.Entities
{
    public class Pelicula
    {
       [Key]
       public int PkPelicula { get; set; }
       public string Titulo { get; set; }
       public List<Genero> Generos { get; set; }

    }
}
