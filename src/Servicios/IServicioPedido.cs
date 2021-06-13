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
        int Guardar(PedidoDTO pedido);
        int Editar(PedidoDTO pedido);
        void Eliminar(int id);
        PedidoDTO ObtenerPedido(int id);

        List<PedidoDTO> ObtenerPedidosSinFiltro();
        List<PedidoDTO> ObtenerPedidosConFiltro(int? id_cliente, int? id_estado, Boolean eliminados, Boolean ult_meses);
        List<ClienteDTO> ObtenerClientes();
        List<EstadoPedidoDTO> ObtenerEstados();
    }
}
