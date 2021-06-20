using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;

namespace Repositorios.Filtros
{
    public class FiltroCompuestoDeClientes : IFiltroCliente
    {
        private List<IFiltroCliente> _filtros;

        public FiltroCompuestoDeClientes()
        {
            _filtros = new List<IFiltroCliente>();
        }

        public bool Evaluar(Cliente cliente)
        {
            bool noEsFiltrado = true;
            for (int i = 0; i < _filtros.Count; i++)
            {
                IFiltroCliente filtro = _filtros[i];
                noEsFiltrado = filtro.Evaluar(cliente) && noEsFiltrado;
            }

            return noEsFiltrado;
        }

        public void Agregar(IFiltroCliente filtro)
        {
            _filtros.Add(filtro);
        }

        public bool TieneFiltros()
        {
            return _filtros.Count > 0;
        }
    }
}
