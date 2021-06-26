using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class PedidoResponse
    {
        public int Count { get; set; }
        public IEnumerable<PedidoDatos> Items { get; set; }
    }
}
