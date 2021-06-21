using DTOs;
using GestorDePedidos.Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public ServicioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        private static UsuarioDTO ConvertirEnDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                EsAdmin = usuario.EsAdmin,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                //¿Esto no podria dar un nullpointer al intentar castear un null?
                FechaNacimiento = (DateTime)usuario.FechaNacimiento,
                Email = usuario.Email,
                Password = usuario.Password
            };
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<Usuario> usuarios = _repositorioUsuario.ObtenerUsuarios();
            return usuarios.Select(usuario => ConvertirEnDTO(usuario)).ToList();
        }


        public void Guardar(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Email = usuarioDTO.Email,
                EsAdmin= usuarioDTO.EsAdmin,
                Apellido = usuarioDTO.Apellido,
                Password = usuarioDTO.Password,
                FechaNacimiento = usuarioDTO.FechaNacimiento,
            };
            _repositorioUsuario.Guardar(usuario);
        }

        public UsuarioDTO ObtenerUsuario(int id)
        {
            Usuario usuario = _repositorioUsuario.ObtenerUsuario(id);
            return ConvertirEnDTO(usuario);
        }

        public void Editar(Usuario usuario)
        {
            _repositorioUsuario.EditarUsuario(usuario);
        }

        public void Eliminar(Usuario usuario)
        {
            _repositorioUsuario.EliminarUsuario(usuario);
        }

        public bool ValidarLogin(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario
            {
                Password = usuarioDTO.Password,
                Email = usuarioDTO.Email
            };

            return _repositorioUsuario.ValidarLogin(usuario);
        }
        public void EditarHora(string email)
        {
            _repositorioUsuario.EditarHora(email);
        }

    }
}