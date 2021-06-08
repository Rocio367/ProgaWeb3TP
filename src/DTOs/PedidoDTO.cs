using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoDTO
    {

        public int IdPedido { set; get; }
        public string Pedido { set; get; }
        public string Estado { set; get; }
        public DateTime? UltModificacion { set; get; }
    }
}
