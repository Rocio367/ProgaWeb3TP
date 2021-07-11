
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Modelos.ModelosApi;
using Repositorios.Filtros.FiltrosArticulo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
   public class RepositorioArticulo : IRepositorioArticulo
    {
        private _20211CTPContext _context;
        private ISession session;
        public RepositorioArticulo(_20211CTPContext contexto)
        {
            _context = contexto;

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
            art.ModificadoPor = articulo.ModificadoPor;
            art.Descripcion = articulo.Descripcion;
            art.FechaModificacion = DateTime.Now;
            _context.SaveChanges();

        }

        public void Eliminar(int id, int idUsuario)
        {
            Articulo art = _context.Articulos.Find(id);
            art.FechaBorrado = DateTime.Now;
            art.BorradoPor = idUsuario;
            _context.SaveChanges();

        }
        public List<Articulo> ObtenerArticulosSinFiltro()
        {
            return _context.Articulos.ToList();
        }

        public List<Articulo> ObtenerArticulosConFiltro(IFiltroArticulo filtro)
        {
            var resultado = _context.Articulos.Where(filtro.Evaluar).Select(articulo => articulo);
            return resultado.ToList();


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

        //API REST
        public ArticuloResponse ObtenerArticulosConFiltroApi(FiltroRequest filtro) {
            var articulos = _context.Articulos.Where(a => a.Descripcion.Contains(filtro.Filtro)).ToList();

            ArticuloResponse respuesta = new ArticuloResponse();
            respuesta.Count = articulos.Count;
            respuesta.Items = articulos.Select(a =>
            {
                return new ArticuloDatos
                {
                    IdArticulo = a.IdArticulo,
                    Codigo = a.Codigo,
                    Descripcion = a.Descripcion,

                };
            });

            return respuesta;
        }

        public bool ExisteArticulo(int id, string codigo, string descripcion)
        {
            if (_context.Articulos.Where(a => a.IdArticulo == id && a.Codigo == codigo && a.Descripcion == descripcion).FirstOrDefault() != null)
            {
                return true;
            }
            else {
                return false;
                    }
        }

        public bool ExisteArticulo(string codigo, string descripcion)
        {
            if (_context.Articulos.Where(a => a.Codigo == codigo && a.Descripcion == descripcion).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
