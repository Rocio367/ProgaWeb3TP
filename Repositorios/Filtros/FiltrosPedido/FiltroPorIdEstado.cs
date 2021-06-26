using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosPedido
{
    public class FiltroPorIdEstado : IFiltrosPedido
    {
        private int? _idEstado;
        public FiltroPorIdEstado(int? idEstado)
        {
            _idEstado = idEstado;
        }
        public bool Evaluar(Pedido pedido)
        {
            return pedido.IdEstado == _idEstado;
        }
    }
}
