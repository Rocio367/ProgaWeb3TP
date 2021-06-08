using ProgaWeb3TP.ContextBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        _20211CTPContext _context;
        public RepositorioPedido()
        {
            _context = new _20211CTPContext();

        }
        public List<EstadoPedido> ObtenerEstados() {
            return _context.EstadoPedidos.ToList();
        }
        public List<Cliente> ObtenerClientes() {
            return _context.Clientes.ToList();
       }
        public List<Pedido> ObtenerPedidosSinFiltro() {
            return _context.Pedidos.ToList();

        }
        public List<Pedido> ObtenerPedidosConFiltro(int id_cliente, int estado, bool eliminados) {
            return _context.Pedidos.ToList();
        }

    }
}
