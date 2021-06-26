using System;
using Repositorios;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using GestorDePedidos.Entidades;
using Repositorios.Filtros.FiltrosArticulo;
namespace Servicios
{
    public class ServicioArticulo : IServicioArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public ServicioArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public void Guardar(ArticuloDTO articuloDTO)
        {
            Articulo aticulo = new Articulo
            {
                Codigo = articuloDTO.Codigo,
                Descripcion = articuloDTO.Descripcion,

            };
            _repositorioArticulo.Guardar(aticulo);
        }
        public void Editar(ArticuloDTO ArticuloDTO)
        {
            Articulo aticulo = new Articulo
            {
                IdArticulo = ArticuloDTO.Id,
                Codigo = ArticuloDTO.Codigo,
                Descripcion = ArticuloDTO.Descripcion,

            };
            _repositorioArticulo.Editar(aticulo);
        }
        public void Eliminar(int id)
        {

            _repositorioArticulo.Eliminar(id);
        }

        public List<ArticuloDTO> ObtenerArticulosSinFiltro()
        {
            List<Articulo> articulos = _repositorioArticulo.ObtenerArticulosSinFiltro();
            return articulos.Select(articulo =>
                new ArticuloDTO
                {
                    Id = articulo.IdArticulo,
                    Codigo = articulo.Codigo,
                    Descripcion = articulo.Descripcion,

                }
            ).ToList();
        }
        public List<ArticuloDTO> ObtenerArticulos(string nombre, string numero, Boolean eliminados)
        {
            FiltroCompuestoDeArticulo filtro = new FiltroCompuestoDeArticulo();
            if (eliminados == true)
            {
                filtro.Agregar(new FiltroDadoDeBajaArticulo());
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                filtro.Agregar(new FiltroPorNombreArticulo(nombre));
            }
            if (!string.IsNullOrWhiteSpace(numero))
            {
                filtro.Agregar(new FiltroPorNumeroArticulo(numero));
            }

            List<Articulo> articulos = null;
            if (filtro.TieneFiltros())
            {
                articulos = _repositorioArticulo.ObtenerArticulosConFiltro(filtro);
            }
            else
            {
                articulos = _repositorioArticulo.ObtenerArticulosSinFiltro();
            }
            return articulos.Select(articulo =>
                new ArticuloDTO
                {
                    Id = articulo.IdArticulo,
                    Codigo = articulo.Codigo,
                    Descripcion = articulo.Descripcion,

                }
            ).ToList();
        }

        public List<string> ObtenerDescripciones()
        {
            return this._repositorioArticulo.ObtenerDescripciones();
        }
        public List<string> ObtenerCodigos()
        {
            return this._repositorioArticulo.ObtenerCodigos();
        }
        public ArticuloDTO ObtenerArticulo(int id)
        {
            Articulo articulo = this._repositorioArticulo.ObtenerArticulo(id);
            ArticuloDTO articuloDTO = new ArticuloDTO
            {
                Id = articulo.IdArticulo,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion
            };
            return articuloDTO;
        }


    }
}
