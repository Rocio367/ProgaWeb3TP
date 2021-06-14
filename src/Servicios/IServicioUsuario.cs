using System.Collections.Generic;
using DTOs;
using ProgaWeb3TP.src.Entidades;

namespace Servicios
{
    public interface IServicioUsuario
    {
        List<UsuarioDTO> ObtenerUsuarios();
        void Guardar(UsuarioDTO usuarioDTO);
        UsuarioDTO ObtenerUsuario(int id);
        void Editar(Usuario usuario);
        void Eliminar(Usuario usuario);
    }
}
