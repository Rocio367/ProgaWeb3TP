using DTOs;
using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioPedido
    {
        void Guardar(PedidoDTO pedido);
        void Editar(PedidoDTO pedido);
        void Eliminar(int id);
        PedidoDTO ObtenerPedido(int id);

        List<PedidoDTO> ObtenerPedidosSinFiltro();
        List<PedidoDTO> ObtenerPedidosConFiltro(int id_cliente, int id_estado, Boolean eliminados);
        List<ClienteDTO> ObtenerClientes();
        List<EstadoPedido> ObtenerEstados();
    }
}
