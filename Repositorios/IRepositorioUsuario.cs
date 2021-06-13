using System.Collections.Generic;
using GestorDePedidos.Entidades;

namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
    }
}
