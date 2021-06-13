using DTOs;
using ProgaWeb3TP.src.Entidades;
using Repositorios;
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

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<Usuario> usuarios = _repositorioUsuario.ObtenerUsuarios();
            return usuarios.Select(usuario=> ConvertirEnDTO(usuario)).ToList();
        }

        private static UsuarioDTO ConvertirEnDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {   IdUsuario = usuario.IdUsuario,
                EsAdmin = usuario.EsAdmin,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                //FechaNacimiento = usuario.FechaNacimiento,
                Email = usuario.Email,
                Password = usuario.Password
            };
        }

        public void Guardar(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Email = usuarioDTO.Email,
                Apellido = usuarioDTO.Apellido,
                Password = usuarioDTO.Password,
                
            };
            _repositorioUsuario.Guardar(usuario);
        }

        public UsuarioDTO ObtenerUsuario(int id)
        {
            Usuario usuario = _repositorioUsuario.ObtenerUsuario(id);
            return ConvertirEnDTO(usuario);
        }

        public void Editar(int id, UsuarioDTO usuarioDTO)
        { 
            List<Usuario> usuarios = _repositorioUsuario.ObtenerUsuarios();
            foreach (Usuario usuario in usuarios)
            {

                if (id == usuario.IdUsuario)
                {
                    usuario.Nombre = usuarioDTO.Nombre;
                    usuario.Email = usuarioDTO.Email;
                    usuario.Apellido = usuarioDTO.Apellido;
                    usuario.Password = usuarioDTO.Password;

                 }
             
            }
        }

        public void Eliminar(int id)
        {
            List<Usuario> usuarios = _repositorioUsuario.ObtenerUsuarios();
            foreach (Usuario usuario in usuarios)
            {

                if (id == usuario.IdUsuario)
                {
                    usuarios.Remove(usuario);
                    break;

                }

            }
        }
    }
}
