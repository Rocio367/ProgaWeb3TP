using System.Collections.Generic;
using DTOs;
namespace Servicios
{
    public interface IServicioUsuario
    {
        List<UsuarioDTO> ObtenerUsuarios();
        void Guardar(UsuarioDTO usuarioDTO);
        UsuarioDTO ObtenerUsuario(int id);
        void Editar(int id, UsuarioDTO usuarioDTO);
        void Eliminar(int id);
    }
}
