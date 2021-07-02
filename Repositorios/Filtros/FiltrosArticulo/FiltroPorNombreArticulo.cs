using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosArticulo
{
    public class FiltroPorNombreArticulo: IFiltroArticulo
    {
        private string _nombre;
        public FiltroPorNombreArticulo(string nombre)
        {
            _nombre = nombre;
        }
        public bool Evaluar(Articulo articulo)
        {
            return articulo.Descripcion.Contains(_nombre,System.StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
