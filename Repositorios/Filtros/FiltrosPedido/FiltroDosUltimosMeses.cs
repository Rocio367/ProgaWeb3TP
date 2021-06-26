using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosPedido
{
    public  class FiltroDosUltimosMeses : IFiltrosPedido
    {
        public bool Evaluar(Pedido pedido)
        {
            DateTime now = DateTime.Now;

            return now.Month - pedido.FechaCreacion.Month <= 2;
        }
    }
}
