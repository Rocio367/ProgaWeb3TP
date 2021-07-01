using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class PedidoResponse
    {
        public int Count { get; set; }
        public List<PedidoDatos> Items { get; set; }
    }
}
