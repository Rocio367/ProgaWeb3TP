using GestorDePedidos.Entidades;
using Modelos.ModelosApi;
using Repositorios.Filtros.FiltrosArticulo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioArticuloEnMemoria : IRepositorioArticulo
    {
        private List<Articulo> _articulos;

        public RepositorioArticuloEnMemoria()
        {
            _articulos = new List<Articulo>();
            Articulo art1 = new Articulo();
            art1.IdArticulo = 1;
            art1.Codigo = "1";
            art1.Descripcion = "Heladera";
            Articulo art2 = new Articulo();
            art2.IdArticulo = 2;
            art2.Codigo = "2";
            art2.Descripcion = "TV";
            Articulo art3 = new Articulo();
            art3.IdArticulo = 3;
            art3.Codigo = "3";
            art3.Descripcion = "Cama";
            _articulos.Add(art1);
            _articulos.Add(art2);
            _articulos.Add(art3);
        }

        public void Guardar(Articulo articulo)
        {
            _articulos.Add(articulo);
        }

        public void Editar(Articulo articulo)
        {

            Articulo art = _articulos.Find(a => a.IdArticulo == articulo.IdArticulo);
            art.Codigo = articulo.Codigo;
            art.Descripcion = articulo.Descripcion;

        }

        public void Eliminar(int id)
        {
            Articulo art = _articulos.Find(a => a.IdArticulo == id);
            art.FechaBorrado = DateTime.Now;
        }

        public List<Articulo> ObtenerArticulos(string nombre, string number, Boolean? eliminados)
        {

            if (nombre!=null || number!=null )
            {
                if (eliminados == true)
                {
                    return _articulos.Where(a => (a.Descripcion == nombre || a.Codigo == number) && a.FechaBorrado.Equals(new DateTime())).ToList();

                }
                else {
                    return _articulos.Where(a => a.Descripcion == nombre || a.Codigo == number).ToList();

                }
            }
            else {
                if (eliminados == true)
                {
                    return _articulos.Where(a => a.FechaBorrado.Equals(new DateTime())).ToList();

                }
                else
                {
                    return _articulos;
                }
            }
        }
        public List<string> ObtenerDescripciones() {
            List<string> descripciones = new List<string>();
            _articulos.ForEach(d => {
                descripciones.Add(d.Descripcion);
            });
            return descripciones.Distinct().ToList();
        }
        public List<string> ObtenerCodigos() {
            List<string> codigos = new List<string>();
            _articulos.ForEach(d => {
                codigos.Add(d.Codigo);
            });
            return codigos.Distinct().ToList();
        }
        public Articulo ObtenerArticulo(int id)
        {

            return _articulos.Find(a => a.IdArticulo == id);
        }

        public List<Articulo> ObtenerArticulosSinFiltro()
        {
            throw new NotImplementedException();
        }

        public List<Articulo> ObtenerArticulosConFiltro(string nombre, string number, bool eliminados)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> ObtenerArticulosConFiltro(IFiltroArticulo filtro)
        {
            throw new NotImplementedException();
        }

        public ArticuloResponse ObtenerArticulosConFiltroApi(FiltroRequest filtro)
        {
            throw new NotImplementedException();
        }
    }
}
