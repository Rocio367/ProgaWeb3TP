using GestorDePedidos.Entidades;
using Repositorios.Filtros;
using System.Collections.Generic;

namespace Repositorios
{
    public interface IRepositorioCliente
    {
        void Guardar(Cliente cliente);
        List<Cliente> ObtenerClientes();
        Cliente ObtenerCliente(int id);
        void Actualizar();
        public List<Cliente> ObtenerClientePorFiltro(IFiltroCliente filtro);

        public List<Cliente> ObtenerClientesParaFiltro();

    }
}
