using Modelos.ModelosApi;
using ApiRest.Services;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidosController : ControllerBase
    {
        private IServicioPedido _servicioPedido;


        public PedidosController(IServicioPedido servicioPedido)

        {
            _servicioPedido = servicioPedido;
        }

        [HttpPost("pedidos/buscar")]
  
        public PedidoResponse Filter(PedidoRequest body)

        {
            return _servicioPedido.BuscarPedidoApi(body);
        }
        [HttpPost("pedidos/guardar")]
        public MensajeResponse Guardar(GuardarPedidoRequest body)
        {
            return _servicioPedido.GuardarPedidoApi(body);
        }

    }
}
