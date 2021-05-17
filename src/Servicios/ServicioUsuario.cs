using DTOs;
using Modelos;
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
                FechaNacimiento = usuario.FechaNacimiento,
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
    }
}
