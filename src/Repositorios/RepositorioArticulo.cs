
using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repositorios
{
    class RepositorioArticulo : IRepositorioArticulo
    {
        _20211CTPContext _context;
        public RepositorioArticulo()
        {
            _context = new _20211CTPContext();

        }
        public void Guardar(Articulo articulo)
        {
            _context.Add(articulo);
            _context.SaveChanges();
        }

        public void Editar(Articulo articulo)
        {

            Articulo art = _context.Articulos.Find(articulo.IdArticulo);
            art.Codigo = articulo.Codigo;
            art.Descripcion = articulo.Descripcion;
            art.FechaModificacion = DateTime.Now;
            _context.SaveChanges();

        }

        public void Eliminar(int id)
        {
            Articulo art = _context.Articulos.Find(id);
            art.FechaBorrado = DateTime.Now;
            _context.SaveChanges();

        }
        public List<Articulo> ObtenerArticulosSinFiltro()
        {
            return _context.Articulos.Where(a =>a.FechaBorrado == null).ToList();
        }

        public List<Articulo> ObtenerArticulosConFiltro(string nombre, string number, Boolean eliminados)
        {
            _20211CTPContext context = new _20211CTPContext();

          
                if (eliminados == true)
                {
                    return _context.Articulos.Where(a =>( a.Descripcion == nombre || a.Codigo == number) && a.FechaBorrado == null).ToList();

                }
                else
                {
                if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(number))
                {
                    return _context.Articulos.Where(a => a.Descripcion == nombre || a.Codigo == number).ToList();
                }
                else {
                    return _context.Articulos.ToList();

                }
            }
            
           
            
        }
        public List<string> ObtenerDescripciones()
        {
            List<string> descripciones = new List<string>();
            _context.Articulos.ToList().ForEach(d => {
                descripciones.Add(d.Descripcion);
            });
            return descripciones.Distinct().ToList();
        }
        public List<string> ObtenerCodigos()
        {
            List<string> codigos = new List<string>();
            _context.Articulos.ToList().ForEach(d => {
                codigos.Add(d.Codigo);
            });
            return codigos.Distinct().ToList();
        }
        public Articulo ObtenerArticulo(int id)
        {

            return _context.Articulos.Find(id);
        }


    }
}
