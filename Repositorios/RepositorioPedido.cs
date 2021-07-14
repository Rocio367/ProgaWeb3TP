using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Modelos.ModelosApi;
using Repositorios.Filtros.FiltrosPedido;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private _20211CTPContext _context;
        public RepositorioPedido(_20211CTPContext contexto)
        {
            _context = contexto;

        }
        public int cambiarEstado(int idPedido, int idEstado,int idUsuario)
        {
            Pedido ped = _context.Pedidos.Find(idPedido);
            ped.IdEstado = idEstado;
            ped.ModificadoPor =idUsuario;
            ped.FechaModificacion = DateTime.Now;
            _context.SaveChanges();
            return ped.NroPedido;
        }

        public int Editar(Pedido pedido)
        {
            Pedido ped = _context.Pedidos.Where(d => d.IdPedido == pedido.IdPedido).Include(d => d.PedidoArticulos).FirstOrDefault();
            ped.PedidoArticulos = pedido.PedidoArticulos;
            ped.Comentarios = pedido.Comentarios;
            ped.ModificadoPor = pedido.ModificadoPor;
            ped.FechaModificacion = DateTime.Now;
            _context.SaveChanges();
            return ped.NroPedido;
        }

        public void Eliminar(int id,int idUsuario)
        {
            Pedido ped = _context.Pedidos.Find(id);
            ped.IdEstado = 2;
            ped.FechaBorrado = DateTime.Now;
            ped.BorradoPor = idUsuario;
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

        // para API REST
        public PedidoResponse BuscarPedidoApi(PedidoRequest body)
        {
            List<Pedido> pedidos = _context.Pedidos.Include(a => a.IdEstadoNavigation).Include(a => a.ModificadoPorNavigation).Include(a => a.PedidoArticulos).ThenInclude(a => a.IdArticuloNavigation).Where(a => a.IdCliente == body.IdCliente && a.IdEstado == body.IdEstado).ToList();

            PedidoResponse respuesta = new PedidoResponse();
            respuesta.Count = pedidos.Count;
            respuesta.Items = pedidos.Select(p =>
            {
                return new PedidoDatos
                {
                    IdPedido = p.IdPedido,
                    IdCliente = p.IdCliente,
                    Estado = p.IdEstadoNavigation.Descripcion,
                    FechaModificacion = p.FechaModificacion,
                    ModificadoPor = (p.ModificadoPorNavigation!=null) ? this.obtenerUsuarioDatos(p): null,
                    Articulos = this.obtenerArticulosPedidoDatos(p)

                };
            }).ToList();

            return respuesta;
        }

        public IEnumerable<ArticuloPedidoDatos> obtenerArticulosPedidoDatos(Pedido pedido)
        {
            IEnumerable<ArticuloPedidoDatos> articulos = pedido.PedidoArticulos.ToList().Select(a =>
            {
                var art = a.IdArticuloNavigation;
                return new ArticuloPedidoDatos
                {
                    IdArticulo = art.IdArticulo,
                    Codigo = art.Codigo,
                    Descripcion = art.Descripcion,
                    Cantidad = a.Cantidad
                };

            });
            return articulos;
        }

        public UsuarioDatos obtenerUsuarioDatos(Pedido p)
        {
            return  new UsuarioDatos
                {
                    IdUsuario = p.ModificadoPorNavigation.IdUsuario,
                    Email = p.ModificadoPorNavigation.Email,
                    Nombre = p.ModificadoPorNavigation.Nombre,
                    Apellido = p.ModificadoPorNavigation.Apellido,
                    FechaNacimiento = p.ModificadoPorNavigation.FechaNacimiento,
                };
        }

        public bool ExisteEstado(int id)
        {
            if (_context.EstadoPedidos.Find(id) != null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public string ExistePedidoAbiertoPorCliente(int id)
        {
            string nombre = "";
            if (_context.Pedidos.Where(a =>a.IdCliente==id && a.FechaBorrado == null && a.IdEstado == 1 ).Count() > 0)
            {
                nombre= _context.Clientes.Find(id).Nombre;
            }
            return nombre;
        }
    }
}
