using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosPedido
{
    public class FiltroPorIdClinte: IFiltrosPedido
    {
        private int? _idCliente;
        public FiltroPorIdClinte(int? idCliente)
        {
            _idCliente = idCliente;
        }
        public bool Evaluar(Pedido pedido)
        {
            return pedido.IdCliente == _idCliente;
        }
    }
}
