
using DTOs;
using System.Collections.Generic;


namespace Servicios
{
    public interface IServicioPedido
    {
        List<EstadoPedidoDTO> ObtenerEstados();
        List<ClienteDTO> ObtenerClientes();
        List<PedidoDTO> ObtenerPedidosSinFiltro();
        List<PedidoDTO> ObtenerPedidosConFiltro(int id_cliente, int estado, bool eliminados);
    }
}
