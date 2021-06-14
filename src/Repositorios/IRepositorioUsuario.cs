using System;
using System.Collections.Generic;
using System.Linq;
using ProgaWeb3TP.src.Entidades;
using System.Threading.Tasks;
using DTOs;

namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
        void EliminarUsuario(Usuario usuario);
    }
}
