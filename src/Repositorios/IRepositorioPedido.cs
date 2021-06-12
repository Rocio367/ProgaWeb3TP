using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.src.Repositorios
{
    public interface IRepositorioPedido
    {
        void Guardar(Pedido pedido);
        void Editar(Pedido pedido);
        void Eliminar(int id);
        Pedido ObtenerPedido(int id);

        List<Pedido> ObtenerPedidosSinFiltro();
        List<Pedido> ObtenerPedidosConFiltro(int id_cliente, int id_estado, Boolean eliminados);
        List<Cliente> ObtenerClientes();
        List<EstadoPedido> ObtenerEstados();
    }
}
