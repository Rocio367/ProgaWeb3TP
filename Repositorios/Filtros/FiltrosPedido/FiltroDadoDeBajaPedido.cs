using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosPedido
{
    public  class FiltroDadoDeBajaPedido :IFiltrosPedido
    {
        public bool Evaluar(Pedido pedido)
        {
            return pedido.FechaBorrado == null;
        }
    }
}
