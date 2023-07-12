using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProyectoFinal_23CV.Context;
using ProyectoFinal_23CV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

                throw new Exception("Succedio un erro "+ex.Message);
            }

        }

        public List<Usuario> GetUsers()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                   List<Usuario> usuarios = new List<Usuario>();

                    usuarios = _context.Usuarios.ToList();

                    return usuarios;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error "+ex.Message);
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

                throw new Exception("Succedio un error"+ex.Message);
            }
        }




    }
}
