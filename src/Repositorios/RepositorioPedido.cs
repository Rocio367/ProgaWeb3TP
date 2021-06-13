using Microsoft.EntityFrameworkCore;
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
            //falta filtro de ult mdificacion
            return _context.Pedidos.Include(e => e.IdClienteNavigation).Include(e => e.ModificadoPorNavigation).Include(e => e.IdEstadoNavigation).Where(a => a.FechaBorrado == null && now.Month - a.FechaCreacion.Month <= 2).ToList();

        }

        public List<Pedido> ObtenerPedidosConFiltro(int? id_cliente, int? id_estado, Boolean eliminados=true, Boolean ult_meses = true)
        {
             DateTime now  = DateTime.Now;

            List<Pedido>  todos=_context.Pedidos.Include(e => e.IdClienteNavigation).Include(e => e.ModificadoPorNavigation).Include(e => e.IdEstadoNavigation).ToList();
            List <Pedido> resultadosFiltro= new List<Pedido>();
            resultadosFiltro = todos;
            if (id_estado != 0 || id_cliente != 0) {
                resultadosFiltro = todos.Where(e => e.IdEstado == id_estado || e.IdCliente == id_cliente).ToList(); ;
            }
           
            if (eliminados)
            {
                if (resultadosFiltro.Count() == 0)
                {
                    resultadosFiltro = todos.Where(e => e.FechaBorrado == null).ToList();
                }
                else {
                    resultadosFiltro = resultadosFiltro.Where(e => e.FechaBorrado == null).ToList();
                }

            }

            if (ult_meses)
            {
                if (resultadosFiltro.Count() == 0)
                {

                   resultadosFiltro = todos.Where(e =>now.Month - e.FechaCreacion.Month <= 1).ToList();
                }
                else
                {
                    resultadosFiltro = resultadosFiltro.Where(e => now.Month - e.FechaCreacion.Month <= 1).ToList();
                }

            }

            return resultadosFiltro;
        }
    }
}
