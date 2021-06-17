using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoArticuloDTO
    {
        public int Id { set; get; }
        public ArticuloDTO articulo { set; get; }
        public int cantidad { set; get; }
    }
}
