using GestorDePedidos.Entidades;

namespace Repositorios.Filtros
{
    public class FiltroPorDadoDeBaja : IFiltroCliente
    {
        public bool Evaluar(Cliente cliente)
        {
            return cliente.FechaBorrado == null;
        }
    }
}
