using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23CV.Context;
using ProyectoFinal_23CV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_23CV.Services
{
    public class UsuarioServices
    {

        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario();
                        res.Nombre = request.Nombre;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        res.FkRol = request.FkRol;
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un erro " + ex.Message);
            }

        }

        public List<Usuario> GetUsers()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    List<Usuario> usuarios = new List<Usuario>();

                    usuarios = _context.Usuarios.Include(x => x.Roles).ToList();

                    return usuarios;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }

        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();

                    return roles;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        public Usuario Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.UserName == UserName && x.Password == Password);


                    return usuario;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
