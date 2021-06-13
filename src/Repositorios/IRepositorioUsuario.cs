using System;
using System.Collections.Generic;
using System.Linq;
using ProgaWeb3TP.src.Entidades;
using System.Threading.Tasks;


namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
    }
}
