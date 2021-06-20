using GestorDePedidos.Entidades;

namespace Repositorios.Filtros
{
    public interface IFiltroCliente
    {
        bool Evaluar(Cliente cliente);
    }
}
