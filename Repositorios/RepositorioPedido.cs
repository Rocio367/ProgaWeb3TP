using GestorDePedidos.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorios.Filtros.FiltrosPedido;
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
        public int cambiarEstado(int idPedido, int idEstado)
        {
            Pedido ped = _context.Pedidos.Find(idPedido);
            //cambiar el modificadoPor por el id del usaurio actual
            ped.IdEstado = idEstado;
            ped.ModificadoPor = 1;
            ped.FechaModificacion = DateTime.Now;
            _context.SaveChanges();
            return ped.NroPedido;
        }

        public int Editar(Pedido pedido)
        {            
            //cambiar el modificadoPor por el id del usaurio actual

            Pedido ped = _context.Pedidos.Find(pedido.IdPedido);
            ped.PedidoArticulos = pedido.PedidoArticulos;
            ped.Comentarios = pedido.Comentarios;
            ped.ModificadoPor = 1;

            ped.FechaModificacion = DateTime.Now;
            _context.SaveChanges();
            return ped.NroPedido;
        }

        public void Eliminar(int id)
        {
            Pedido ped = _context.Pedidos.Find(id);
            ped.FechaBorrado = DateTime.Now;
            _context.SaveChanges();
        }

        public int Guardar(Pedido pedido)
        {
            pedido.IdEstado = 1;
            pedido.FechaCreacion = DateTime.Now;
            pedido.NroPedido = (_context.Pedidos.Max(d => d.NroPedido))+1;
            _context.Add(pedido);
            _context.SaveChanges();
            return pedido.NroPedido;
        }

        public List<Cliente> ObtenerClientesFiltro()
        {
       
            return _context.Clientes.ToList();
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> resultados = new List<Cliente>();
            List<Cliente> resultadosBD = _context.Clientes.Include(e => e.Pedidos).Where(e => e.FechaBorrado == null).ToList();
            resultadosBD.ForEach(e =>
            {
                if (e.Pedidos.Where(d => d.IdEstado == 1).ToList().Count() <= 1)
                {
                    resultados.Add(e);
                }
            });

            return resultados;
        }

        List<EstadoPedido> IRepositorioPedido.ObtenerEstados()
        {
            return _context.EstadoPedidos.ToList();
        }

        public Pedido ObtenerPedido(int id)
        {
            return _context.Pedidos.Include(e => e.IdClienteNavigation).Include(e => e.ModificadoPorNavigation).Include(e => e.PedidoArticulos).Include(e => e.IdEstadoNavigation).Where(a => a.IdPedido == id).FirstOrDefault(); 
        }

        public List<Pedido> ObtenerPedidosSinFiltro()
        {
            DateTime now = DateTime.Now;
            return _context.Pedidos.Include(e => e.IdClienteNavigation).Include(e => e.ModificadoPorNavigation).Include(e => e.IdEstadoNavigation).ToList();

        }

        public List<Pedido> ObtenerPedidosConFiltro(IFiltrosPedido  filtro)
        {
            var resultado = _context.Pedidos.Include(e => e.IdClienteNavigation).Include(e => e.ModificadoPorNavigation).Include(e => e.IdEstadoNavigation).Where(filtro.Evaluar).Select(articulo => articulo);
            return resultado.ToList();
        }
    }
}
