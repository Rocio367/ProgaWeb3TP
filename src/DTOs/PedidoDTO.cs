using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoDTO
    {

        public int IdPedido { get; set; }
        public int idCliente { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
