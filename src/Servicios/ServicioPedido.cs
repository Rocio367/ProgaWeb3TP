using DTOs;
using ProgaWeb3TP.src.Entidades;
using ProgaWeb3TP.src.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPedido : IServicioPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public ServicioPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public void Editar(PedidoDTO pedido)
        {
            //fijarse que datos se modifican 
            Pedido ped = new Pedido
            {
               /* IdArticulo = ArticuloDTO.Id,
                Codigo = ArticuloDTO.Codigo,
                Descripcion = ArticuloDTO.Descripcion,*/

            };
            _repositorioPedido.Editar(ped);
        }

        public void Eliminar(int id)
        {
            _repositorioPedido.Eliminar(id);
        }

        public void Guardar(PedidoDTO pedido)
        {
            //fijarse qe datos se guardan
            Pedido ped = new Pedido
            {
                IdPedido = pedido.IdPedido,
                IdCliente = pedido.idCliente,
                IdEstado = pedido.IdEstado,
             //   FechaCreacion = ped.FechaCreacion,

            };
            _repositorioPedido.Guardar(ped);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            List<Cliente> clientes = _repositorioPedido.ObtenerClientes();
            return clientes.Select(cli =>
                new ClienteDTO
                {
                    IdCliente = cli.IdCliente,
                    Nombre = cli.Nombre,
                   

                }
            ).ToList();
        }

        public List<EstadoPedido> ObtenerEstados()
        {
            return _repositorioPedido.ObtenerEstados();
        }

        public PedidoDTO ObtenerPedido(int id)
        {
            //fijarse si falta algun dato
            Pedido ped = this._repositorioPedido.ObtenerPedido(id);
            PedidoDTO pedidoDTO = new PedidoDTO
            {
                IdPedido = ped.IdPedido,
                idCliente = ped.IdCliente,
                IdEstado = ped.IdEstado,
                FechaCreacion = ped.FechaCreacion,
                FechaModificacion = ped.FechaModificacion,
            };
            return pedidoDTO;
        }

        public List<PedidoDTO> ObtenerPedidosConFiltro(int id_cliente, int id_estado, bool eliminados)
        {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosConFiltro(id_cliente,id_estado,eliminados);
            return pedidos.Select(ped =>
                new PedidoDTO
                { 
                    IdPedido= ped.IdPedido,
                    idCliente=ped.IdCliente,
                    IdEstado = ped.IdEstado,
                    FechaCreacion = ped.FechaCreacion,
                    FechaModificacion = ped.FechaModificacion,

    }
            ).ToList();
        }

        public List<PedidoDTO> ObtenerPedidosSinFiltro()
        {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosSinFiltro();
            return pedidos.Select(ped =>
                new PedidoDTO
                {
                    IdPedido = ped.IdPedido,
                    idCliente = ped.IdCliente,
                    IdEstado = ped.IdEstado,
                    FechaCreacion = ped.FechaCreacion,
                    FechaModificacion = ped.FechaModificacion,

                }
            ).ToList();
        }
    }
}
