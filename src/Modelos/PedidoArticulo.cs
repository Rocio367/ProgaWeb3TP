using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class PedidoArticulo
    {
        public Pedido IdPedido { set; get; }
        public Articulo IdArticulo { set; get; }
        public int Cantidad { set; get; }

}
