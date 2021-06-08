<<<<<<< Updated upstream
﻿using System;
=======
﻿
using DTOs;
using ProgaWeb3TP.ContextBD;
using Repositorios;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    class ServicioPedido : IServicioPedido
    {
<<<<<<< Updated upstream
=======
        private IRepositorioPedido _repositorioPedido;
        public ServicioPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public List<EstadoPedidoDTO> ObtenerEstados() {
            List<EstadoPedido> estados = _repositorioPedido.ObtenerEstados();
            return estados.Select(estado =>
                new EstadoPedidoDTO
                {
                    IdEstadoPedido = estado.IdEstadoPedido,
                    Descripcion = estado.Descripcion
                 }).ToList();
        }
        public List<ClienteDTO> ObtenerClientes() {
            List<Cliente> clientes = _repositorioPedido.ObtenerClientes();
            return clientes.Select(cliente =>
                new ClienteDTO { 
                       Nombre=cliente.Nombre,
                       IdCliente =cliente.IdCliente
      
                }).ToList();
        }
        public List<PedidoDTO> ObtenerPedidosSinFiltro() {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosSinFiltro();
            return pedidos.Select(pedido =>
                new PedidoDTO
                {
                    IdPedido = pedido.IdPedido,
                    Pedido = pedido.NroPedido.ToString(),
                    Estado = pedido.IdEstado.ToString(),
                    UltModificacion = (pedido.FechaModificacion == DateTime.MinValue) ? pedido.FechaModificacion: pedido.FechaModificacion,
                }).ToList();
        }
        public List<PedidoDTO> ObtenerPedidosConFiltro(int id_cliente, int estado, bool eliminados) {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosConFiltro(id_cliente,estado,eliminados);
            return pedidos.Select(pedido =>
                new PedidoDTO
                {
                    IdPedido = pedido.IdPedido,
                    Pedido = pedido.NroPedido.ToString(),
                    Estado = pedido.IdEstado.ToString(),
                    UltModificacion = (pedido.FechaModificacion == DateTime.MinValue) ? pedido.FechaModificacion : pedido.FechaModificacion,
                }).ToList();
        }

>>>>>>> Stashed changes
    }
}
