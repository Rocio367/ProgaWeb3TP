
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    class RepositorioArticulo : IRepositorioArticulo
    {
        private List<Articulo> _articulos;

        public void Guardar(Articulo articulo)
        {
            _articulos.Add(articulo);
        }

        public void Editar(Articulo articulo)
        {
            var index = _articulos.IndexOf(articulo);
            _articulos.RemoveAt(index);
            _articulos.Insert(index,articulo);

        }

        public void Eliminar(Articulo articulo)
        {
            var index = _articulos.IndexOf(articulo);
            _articulos.RemoveAt(index);

        }

        public List<Articulo> ObtenerArticulos()
        {
            return _articulos;
        }
    }
}
