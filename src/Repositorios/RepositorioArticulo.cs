
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
            art.FechaBorrado = DateTime.Now;
        }

        public List<Articulo> ObtenerArticulos(string nombre, string number, Boolean? eliminados)
        {

            if (nombre!=null || number!=null )
            {
                if (eliminados == true)
                {
                    return Datos.Articulos.Where(a => (a.Descripcion == nombre || a.Codigo == number) && a.FechaBorrado.Equals(new DateTime())).ToList();

                }
                else {
                    return Datos.Articulos.Where(a => a.Descripcion == nombre || a.Codigo == number).ToList();

                }
            }
            else {
                if (eliminados == true)
                {
                    return Datos.Articulos.Where(a => a.FechaBorrado.Equals(new DateTime())).ToList();

                }
                else
                {
                    return Datos.Articulos;

                }
            }
        }
        public List<string> ObtenerDescripciones() {
            List<string> descripciones = new List<string>();
            Datos.Articulos.ForEach(d => {
                descripciones.Add(d.Descripcion);
            });
            return descripciones.Distinct().ToList();
        }
        public List<string> ObtenerCodigos() {
            List<string> codigos = new List<string>();
            Datos.Articulos.ForEach(d => {
                codigos.Add(d.Codigo);
            });
            return codigos.Distinct().ToList();
        }
        public Articulo ObtenerArticulo(int id)
        {

            return Datos.Articulos.Find(a => a.IdArticulo == id);
        }


    }
}
