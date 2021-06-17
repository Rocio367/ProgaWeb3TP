using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWeb.Models
{
    public class CrearPedidoVM
    {
        public PedidoDTO pedido { get; set; }
        public List<ClienteDTO> Clientes { get; set; }
        public List<ArticuloDTO> Articulos { get; set; }

    }
}
