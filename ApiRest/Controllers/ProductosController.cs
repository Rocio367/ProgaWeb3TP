using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos.ModelosApi;
using Servicios;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ProductosController : ControllerBase
    {

        private IServicioArticulo _servicioArticulo;


        public ProductosController(IServicioArticulo servicioArticulo)

        {
            _servicioArticulo = servicioArticulo;
        }

        [HttpGet]
        public ArticuloResponse Get()
        {
            return _servicioArticulo.ObtenerArticulosApi();
        }

        [HttpPost("filtrar")]
        public ArticuloResponse Filter(FiltroRequest filtro)
        {
            return _servicioArticulo.FiltrarArticulosApi(filtro);
        }
    }
}
