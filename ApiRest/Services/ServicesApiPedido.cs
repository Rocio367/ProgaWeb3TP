using ApiRest.Modelo;
using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class ServicesApiPedido
    {
        private _20211CTPContext _contexto;

        public ServicesApiPedido(_20211CTPContext context)
        {
            _contexto = context;
        }
        public IEnumerable<ArticuloPedidoDatos> obtenerArticulosPedidoDatos(Pedido pedido)
        {
            IEnumerable<ArticuloPedidoDatos> articulos = pedido.PedidoArticulos.ToList().Select(a =>
            {
                var art = this.obtenerArticuloDatos(a.IdArticulo);
                return new ArticuloPedidoDatos
                {
                    IdArticulo = art.IdArticulo,
                    Codigo = art.Codigo,
                    Descripcion = art.Descripcion,
                    Cantidad = a.Cantidad
                };

            });
            return articulos;
        }

        public ArticuloDatos obtenerArticuloDatos(int id)
        {
            var articulo = _contexto.Articulos.Where(a => a.IdArticulo == id).FirstOrDefault();


            return new ArticuloDatos
            {
                IdArticulo = articulo.IdArticulo,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,


            };

        }
    }
}
