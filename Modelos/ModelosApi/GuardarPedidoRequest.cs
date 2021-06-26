using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class GuardarPedidoRequest
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public ModificadoPor ModificadoPor { get; set; }
        public List<ArticuloPedidoDatos> Articulos { get; set; }

    }
}
