using API.Controllers;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.ModelosApi;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        private IServicioArticulo _servicioArticulo;

        public ArticuloController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }

        [HttpGet("productos")]
        public ArticuloResponse Get()
        {
            return _servicioArticulo.ObtenerArticulosApi();
        }

        [HttpPost("productos/filtrar")]
        public ArticuloResponse Filter(FiltroRequest filtro)
        {
            return _servicioArticulo.FiltrarArticulosApi(filtro);
        }
    }
}
