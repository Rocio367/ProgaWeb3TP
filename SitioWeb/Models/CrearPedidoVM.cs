using DTOs;
using System.Collections.Generic;

namespace SitioWeb.Models
{
    public class CrearPedidoVM
    {
        public PedidoDTO pedido { get; set; }
        public List<ClienteDTO> Clientes { get; set; }
        public List<ArticuloDTO> Articulos { get; set; }

    }
}
