﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal_23CV.Context;

namespace ProyectoFinal_23CV.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosPkGenero")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasPkPelicula")
                        .HasColumnType("int");

                    b.HasKey("GenerosPkGenero", "PeliculasPkPelicula");

                    b.HasIndex("PeliculasPkPelicula");

                    b.ToTable("GeneroPelicula");
                });

            modelBuilder.Entity("ProyectoFinal_23CV.Entities.Genero", b =>
                {
                    b.Property<int>("PkGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ProyectoFinal_23CV.Entities.Pelicula", b =>
                {
                    b.Property<int>("PkPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkPelicula");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ProyectoFinal_23CV.Entities.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoFinal_23CV.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("ProyectoFinal_23CV.Entities.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosPkGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_23CV.Entities.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasPkPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinal_23CV.Entities.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal_23CV.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
