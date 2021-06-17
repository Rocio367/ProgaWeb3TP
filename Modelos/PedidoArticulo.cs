namespace Modelos
{
    class PedidoArticulo
    {
        public Pedido IdPedido { set; get; }
        public Articulo IdArticulo { set; get; }
        public int Cantidad { set; get; }
    }
}
