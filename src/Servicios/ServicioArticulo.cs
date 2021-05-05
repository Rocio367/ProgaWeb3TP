using System;
using Repositorios;
using DTOs;
using Modelos;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    class ServicioArticulo: IServicioArticulo
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
        void Editar(ArticuloDTO ArticuloDTO) {
            Articulo aticulo = new Articulo
            {
                Codigo = ArticuloDTO.Codigo,
                Descripcion = ArticuloDTO.Descripcion,

            };
            _repositorioArticulo.Editar(aticulo);
        }
        void Eliminar(ArticuloDTO ArticuloDTO) {
            Articulo aticulo = new Articulo
            {
                Codigo = ArticuloDTO.Codigo,
                Descripcion = ArticuloDTO.Descripcion,

            };
            _repositorioArticulo.Eliminar(aticulo);
        }
        public List<ArticuloDTO> ObtenerArticulos()
        {
            List<Articulo> articulos = _repositorioArticulo.ObtenerArticulos();
            return articulos.Select(articulo =>
                new ArticuloDTO
                {
                    Codigo = articulo.Codigo,
                    Descripcion = articulo.Descripcion,
                   
                }
            ).ToList();
        }
    }
}
