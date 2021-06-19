using DTOs;
using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioPedido
    {
        int Guardar(PedidoDTO pedido);
        int Editar(PedidoDTO pedido);
        void Eliminar(int id);
        PedidoDTO ObtenerPedido(int id);
        int cambiarEstado(int idPedido, int idEstado);
        List<PedidoDTO> ObtenerPedidosSinFiltro();
        List<PedidoDTO> ObtenerPedidosConFiltro(int? id_cliente, int? id_estado, Boolean eliminados, Boolean ult_meses);
        List<ClienteDTO> ObtenerClientes();
        List<ClienteDTO> ObtenerClientesFiltro();

        List<EstadoPedidoDTO> ObtenerEstados();
    }
}
