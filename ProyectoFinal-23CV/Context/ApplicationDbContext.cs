using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoFinal_23CV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23CV.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        static readonly string connectionString = "Server=localhost;port=5506;User ID=root2; Password=; Database=ProyectoDb23cv";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // este es de usted profa
            options.UseMySQL("server =localhost; database= ProyectoDb23cv; user= root; password=");
            // este es mio 
            //options.UseMySql(connectionString , ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pelicula_Has_Genero>()
                .HasKey(ep => new { ep.PeliculaId, ep.GeneroId });

            modelBuilder.Entity<Pelicula_Has_Genero>()
                .HasOne(ep => ep.Genero)
                .WithMany(e => e.PeliculasGenero)
                .HasForeignKey(ep => ep.GeneroId);

            modelBuilder.Entity<Pelicula_Has_Genero>()
                .HasOne(ep => ep.Pelicula)
                .WithMany(p => p.PeliculasGenero)
                .HasForeignKey(ep => ep.PeliculaId);

            // Insert para la tabla de Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Usuario 1",
                    UserName = "user1",
                    Password = "password1",
                    FkRol = 1 // Aquí debes proporcionar el ID del rol correspondiente
                },
                new Usuario
                {
                    PkUsuario = 2,
                    Nombre = "Usuario 2",
                    UserName = "user2",
                    Password = "password2",
                    FkRol = 2 // Aquí debes proporcionar el ID del rol correspondiente
                }
            // Agrega más usuarios si es necesario
            );

            // Insert para la tabla de Roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Administrador"
                },
                new Rol
                {
                    PkRol = 2,
                    Nombre = "Usuario Normal"
                }
            // Agrega más roles si es necesario
            );

            // Insert para la tabla de Generos
            modelBuilder.Entity<Genero>().HasData(
                new Genero
                {
                    PkGenero = 1,
                    Nombre = "Acción"
                },
                new Genero
                {
                    PkGenero = 2,
                    Nombre = "Comedia"
                }
            // Agrega más géneros si es necesario
            );

            // Insert para la tabla de Peliculas
            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    PkPelicula = 1,
                    Titulo = "Pelicula 1"
                    // Agrega los géneros correspondientes a esta película mediante el método Include
                },
                new Pelicula
                {
                    PkPelicula = 2,
                    Titulo = "Pelicula 2"
                    // Agrega los géneros correspondientes a esta película mediante el método Include
                }
            // Agrega más películas si es necesario
            );
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    var rol = new Rol{ Nombre = "soporte"};
        //    var rol2 = new Rol { Nombre = "Bd" };

        //    builder.Entity<Rol>().HasData(rol, rol2);
        //    base.OnModelCreating(builder);

        //}

    }
}
