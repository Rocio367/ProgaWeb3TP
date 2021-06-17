using DTOs;
using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioPedido
    {
        int Guardar(PedidoDTO pedido);
        void Editar(PedidoDTO pedido);
        void Eliminar(int id);
        PedidoDTO ObtenerPedido(int id);

        List<PedidoDTO> ObtenerPedidosSinFiltro();
        List<PedidoDTO> ObtenerPedidosConFiltro(int id_cliente, int id_estado, Boolean eliminados);
        List<ClienteDTO> ObtenerClientes();
        List<EstadoPedido> ObtenerEstados();
    }
}
