using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosPedido
{
    public  class FiltroCompuestoDePedido : IFiltrosPedido
    {
        private List<IFiltrosPedido> _filtros;

        public FiltroCompuestoDePedido()
        {
            _filtros = new List<IFiltrosPedido>();
        }

        public bool Evaluar(Pedido pedido)
        {
            bool noEsFiltrado = true;
            for (int i = 0; i < _filtros.Count; i++)
            {
                IFiltrosPedido filtro = _filtros[i];
                noEsFiltrado = filtro.Evaluar(pedido) && noEsFiltrado;
            }

            return noEsFiltrado;
        }

        public void Agregar(IFiltrosPedido filtro)
        {
            _filtros.Add(filtro);
        }

        public bool TieneFiltros()
        {
            return _filtros.Count > 0;
        }
    }
}
