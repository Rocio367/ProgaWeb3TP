using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosArticulo
{
    public class FiltroCompuestoDeArticulo :IFiltroArticulo
    {
        private List<IFiltroArticulo> _filtros;

        public FiltroCompuestoDeArticulo()
        {
            _filtros = new List<IFiltroArticulo>();
        }

        public bool Evaluar(Articulo articulo)
        {
            bool noEsFiltrado = true;
            for (int i = 0; i < _filtros.Count; i++)
            {
                IFiltroArticulo filtro = _filtros[i];
                noEsFiltrado = filtro.Evaluar(articulo) && noEsFiltrado;
            }

            return noEsFiltrado;
        }

        public void Agregar(IFiltroArticulo filtro)
        {
            _filtros.Add(filtro);
        }

        public bool TieneFiltros()
        {
            return _filtros.Count > 0;
        }
    }
}
