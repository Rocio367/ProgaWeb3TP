using GestorDePedidos.Entidades;
using System;

namespace Repositorios.Filtros.FiltrosPedido
{
    public  class FiltroDosUltimosMeses : IFiltrosPedido
    {
        public bool Evaluar(Pedido pedido)
        {
            DateTime now = DateTime.Now;
            DateTime dosMesesAtras = now.AddMonths(-2);
            return pedido.FechaCreacion >= dosMesesAtras && pedido.FechaCreacion <= now;
        }
    }
}
