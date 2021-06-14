﻿using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Repositorios
{
    class RepositorioUsuario : IRepositorioUsuario
    {

        private _20211CTPContext _contexto;
        public RepositorioUsuario(_20211CTPContext contexto)
        {
            _contexto = contexto;
        }
        public void Guardar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuario ObtenerUsuario(int id)
        {
            return _contexto.Usuarios.Find(id);
        }
        public void EditarUsuario(Usuario usuario)
        {
            Usuario actual = _contexto.Usuarios.Find(usuario.IdUsuario);
            actual.Nombre = usuario.Nombre;
            actual.Apellido = usuario.Apellido;
            actual.Email = usuario.Email;
            actual.Password= usuario.Password;
            actual.FechaNacimiento = usuario.FechaNacimiento;
            actual.FechaModificacion = DateTime.Now;

            _contexto.SaveChanges();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _contexto.Usuarios.ToList();
        }
        public void EliminarUsuario(Usuario usuario)
        {
            Usuario actual = _contexto.Usuarios.Find(usuario.IdUsuario);
            actual.FechaBorrado = DateTime.Now;
            _contexto.SaveChanges();
        }
    }
}
