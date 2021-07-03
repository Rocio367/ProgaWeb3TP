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
        private IServicioCliente _servicioCliente;
        private IServicioUsuario _servicioUsuario;
        private IServicioArticulo _servicioArticulo;


        public PedidosController(IServicioPedido servicioPedido, IServicioArticulo servicioArticulo,
            IServicioCliente servicioCliente, IServicioUsuario servicioUsuario)

        {
            _servicioPedido = servicioPedido;
            _servicioCliente = servicioCliente;
            _servicioUsuario = servicioUsuario;
            _servicioArticulo = servicioArticulo;
        }

        [HttpPost("buscar")]
  
        public ActionResult Filter(PedidoRequest body)
        {
            MensajeResponse mensaje= new MensajeResponse();
            if (body.IdEstado== 0 || body.IdCliente== 0)
            {
                mensaje.Mensaje = "El body debe contener los siguiente datos : IdCliente ,IdEstado ";
                return BadRequest(mensaje);
            }
            if (!_servicioPedido.ExisteEstado(body.IdEstado) )
            {
                mensaje.Mensaje = "El 'IdEstado' ingresado no fue encontrado en la base de dats ";
                return NotFound(mensaje);
            }

            if (!_servicioCliente.ExisteCliente(body.IdCliente))
            {
                mensaje.Mensaje = "El 'IdCliente' ingresado no fue encontrado en la base de dats ";
                return NotFound(mensaje);
            }

            return Ok(_servicioPedido.BuscarPedidoApi(body));
        }
        [HttpPost("guardar")]
        public ActionResult Guardar(GuardarPedidoRequest body)
        {
            MensajeResponse mensaje = new MensajeResponse();
            if (body.ModificadoPor.IdUsuario == 0 || body.IdCliente == 0 || body.Articulos == null)
            {
                mensaje.Mensaje = "El body debe contener los siguiente datos : IdCliente ,ModificadoPor.IdUsuario,Articulos ";
                return BadRequest(mensaje);
            }

            if (body.Articulos.Count() == 0)
            {
                mensaje.Mensaje = "Se debe ingresar como minimo un articulo para crear un pedido";
                return BadRequest(mensaje);
            }

            if (!_servicioArticulo.ExisteListaDeArticulo(body.Articulos))
            {
                mensaje.Mensaje = "Alguno de los articulos ingresados no existe en la base de datos";
                return NotFound(mensaje);
            }
            if (!_servicioUsuario.ExisteUsuario(body.ModificadoPor.IdUsuario))
             {
                 mensaje.Mensaje = "El 'ModificadoPor.IdUsuario' ingresado no fue encontrado en la base de datos ";
                 return NotFound(mensaje);
             }

            if (!_servicioCliente.ExisteCliente(body.IdCliente))
            {
                mensaje.Mensaje = "El 'IdCliente' ingresado no fue encontrado en la base de datos ";
                return NotFound(mensaje);
            }

            return Ok(_servicioPedido.GuardarPedidoApi(body));
        }


    }
}
