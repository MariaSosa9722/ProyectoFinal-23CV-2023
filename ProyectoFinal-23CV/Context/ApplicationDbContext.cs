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
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server =localhost; database= ProyectoDb23cv; user= root; password=");
          


        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    var rol = new Rol{ Nombre = "soporte"};
        //    var rol2 = new Rol { Nombre = "Bd" };

        //    builder.Entity<Rol>().HasData(rol, rol2);
        //    base.OnModelCreating(builder);

        //}

    }
}
