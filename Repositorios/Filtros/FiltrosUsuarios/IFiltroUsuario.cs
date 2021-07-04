using GestorDePedidos.Entidades;

namespace Repositorios.Filtros.FiltrosUsuarios
{
    public interface IFiltroUsuario
    {
        bool Evaluar(Usuario usuario);
    }
}
