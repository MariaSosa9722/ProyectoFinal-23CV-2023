using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23CV.Context;
using ProyectoFinal_23CV.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23CV.Services
{
    public class PeliculaService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public Pelicula? GetPeliculaById(int id)
        {
            return this.db.Peliculas
                .Include(p => p.Generos)
                .FirstOrDefault(p => p.PkPelicula == id);
        }

        public Genero? GetGenero(int id)
        {
            return this.db.Generos
                .FirstOrDefault(p => p.PkGenero == id);
        }
        public List<Pelicula> GetAllPeliculas()
        {
            return this.db.Peliculas
                .Include(p => p.Generos)
                .ToList();
        }

        public Pelicula? AddPelicula(Pelicula pelicula)
        {
            try
            {
                this.db.Peliculas.Add(pelicula);
                this.db.SaveChanges();
                return pelicula;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool UpdatePelicula(Pelicula pelicula)
        {
            try
            {
                Pelicula? existe = this.db.Peliculas.FirstOrDefault(p => p.PkPelicula == pelicula.PkPelicula);

                if (existe == null)
                {
                    return false;
                }

                this.db.Peliculas.Update(pelicula);

                this.db.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeletePelicula(int id)
        {
            try
            {
                Pelicula? pelicula = this.db.Peliculas.FirstOrDefault(p => p.PkPelicula == id);

                if (pelicula == null)
                    return false;

                this.db.Peliculas.Remove(pelicula);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
