using API.Controllers;
using ApiRest.Modelo;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductosController : ControllerBase
    {

        private _20211CTPContext _contexto;

        public ProductosController(_20211CTPContext context)
        {
            _contexto = context;
        }

        [HttpGet]
        public ArticuloResponse Get()
        {
            var articulos = _contexto.Articulos.ToList();

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

        [HttpPost("filtrar")]
        public ArticuloResponse Filter(FiltroRequest filtro)
        {
            var articulos = _contexto.Articulos.Where(a => a.Descripcion.Contains(filtro.Filtro)).ToList();

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
    }
}
