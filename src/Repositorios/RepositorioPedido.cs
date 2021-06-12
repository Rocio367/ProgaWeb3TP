using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.src.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        _20211CTPContext _context;
        public RepositorioPedido()
        {
            _context = new _20211CTPContext();

        }
        public void Editar(Pedido pedido)
        {
            Pedido ped = _context.Pedidos.Find(pedido.IdPedido);
            // falta ver las propiedades a editar
            ped.FechaModificacion = DateTime.Now;
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Pedido ped = _context.Pedidos.Find(id);
            ped.FechaBorrado = DateTime.Now;
            _context.SaveChanges();
        }

        public void Guardar(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
        }

        public List<Cliente> ObtenerClientes()
        {
            return _context.Clientes.ToList();
        }

        List<EstadoPedido> IRepositorioPedido.ObtenerEstados()
        {
            return _context.EstadoPedidos.ToList();
        }

        public Pedido ObtenerPedido(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public List<Pedido> ObtenerPedidosSinFiltro()
        {
            return _context.Pedidos.Where(a => a.FechaBorrado == null).ToList();

        }

        public List<Pedido> ObtenerPedidosConFiltro(int id_cliente, int id_estado, bool eliminados)
        {
            if (eliminados == true)
            {
                return _context.Pedidos.Where(a => (a.IdCliente == id_cliente || a.IdEstado == id_estado) && a.FechaBorrado == null).ToList();

            }
            else
            {
                if (id_estado == 0 || id_cliente == 0)
                {
                    return _context.Pedidos.Where(a => a.IdCliente == id_cliente || a.IdEstado == id_estado).ToList();
                }
                else
                {
                    return _context.Pedidos.ToList();

                }
            }
        }
    }
}
