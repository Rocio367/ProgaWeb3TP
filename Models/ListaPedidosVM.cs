using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.Models
{
    public class ListaPedidosVM
    {
        public int id_cliente { get; set; }

        public string estado { get; set; }

        public int id_estado { get; set; }
        public Boolean eliminados { get; set; }

        public PagedList.IPagedList<PedidoDTO> pedidos { get; set; }
        public List<ClienteDTO> clientes { get; set; }
        public List<string> estados { get; set; }
        public List<EstadoPedidoDTO> estados { get; set; }
    }
}
