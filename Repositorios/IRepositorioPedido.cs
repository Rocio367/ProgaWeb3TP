using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositorioPedido
    {
        int Guardar(Pedido pedido);
        void Editar(Pedido pedido);
        void Eliminar(int id);
        Pedido ObtenerPedido(int id);

        List<Pedido> ObtenerPedidosSinFiltro();
        List<Pedido> ObtenerPedidosConFiltro(int id_cliente, int id_estado, Boolean eliminados);
        List<Cliente> ObtenerClientes();
        List<EstadoPedido> ObtenerEstados();
    }
}
