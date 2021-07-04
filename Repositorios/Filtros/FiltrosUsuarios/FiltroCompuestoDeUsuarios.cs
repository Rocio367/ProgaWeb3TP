using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;

namespace Repositorios.Filtros.FiltrosUsuarios
{
    public class FiltroCompuestoDeUsuarios : IFiltroUsuario
    {
        private List<IFiltroUsuario> _filtros;

        public FiltroCompuestoDeUsuarios()
        {
            _filtros = new List<IFiltroUsuario>();
        }

        public bool Evaluar(Usuario usuario)
        {
            bool noEsFiltrado = true;
            for (int i = 0; i < _filtros.Count; i++)
            {
                IFiltroUsuario filtro = _filtros[i];
                noEsFiltrado = filtro.Evaluar(usuario) && noEsFiltrado;
            }

            return noEsFiltrado;
        }

        public void Agregar(IFiltroUsuario filtro)
        {
            _filtros.Add(filtro);
        }

        public bool TieneFiltros()
        {
            return _filtros.Count > 0;
        }
    }
}
