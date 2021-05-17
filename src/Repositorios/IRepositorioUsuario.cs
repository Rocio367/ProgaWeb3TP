using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
    }
}
