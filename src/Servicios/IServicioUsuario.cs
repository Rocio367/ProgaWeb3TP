using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using System.Collections.Generic;
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
