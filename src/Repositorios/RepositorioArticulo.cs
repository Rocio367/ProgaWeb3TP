
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

        public void Guardar(Articulo articulo)
        {
            Datos.Articulos.Add(articulo);
        }

        public void Editar(Articulo articulo)
        {

            Articulo art = Datos.Articulos.Find(a => a.IdArticulo == articulo.IdArticulo);
            art.Codigo = articulo.Codigo;
            art.Descripcion = articulo.Descripcion;

        }

        public void Eliminar(int id)
        {
            Articulo art = Datos.Articulos.Find(a => a.IdArticulo == id);
            Datos.Articulos.Remove(art);

        }

        public List<Articulo> ObtenerArticulos()
        {
            return Datos.Articulos;
        }

        public Articulo ObtenerArticulo(int id)
        {

            return Datos.Articulos.Find(a => a.IdArticulo == id);
        }


    }
}
