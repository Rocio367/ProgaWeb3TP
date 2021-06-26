using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosArticulo
{
    public class FiltroDadoDeBajaArticulo : IFiltroArticulo
    {
        public bool Evaluar(Articulo articulo)
        {
            return articulo.FechaBorrado == null;
        }

    }
}
