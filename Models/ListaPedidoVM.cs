using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.Models
{
    public class ListaPedidoVM
    {
        public int? id_estado { get; set; }
        public int? id_cliente { get; set; }

        public Boolean solo_ultimos_dos_meses { get; set; }

        public Boolean eliminados { get; set; }

        public PagedList.IPagedList<DTOs.PedidoDTO> pedidos { get; set; }
        public List<EstadoPedidoDTO> estados { set; get; }
        public List<ClienteDTO> clientes { set; get; }

    }
}
