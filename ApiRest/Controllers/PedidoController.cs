using ApiRest.Modelo;
using ApiRest.Services;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private _20211CTPContext _contexto;
        private  ServicesApiPedido _servicesApiPedido; 

        public PedidoController(_20211CTPContext context)
        {
            _contexto = context;
        }
        [HttpPost("pedidos/buscar")]
        public PedidoResponse Filter(PedidoRequest body)
        {
            List<Pedido> pedidos = _contexto.Pedidos.Include(a => a.IdEstadoNavigation).Include(a => a.ModificadoPorNavigation).Include(a => a.PedidoArticulos).Where(a => a.IdCliente== body.IdCliente && a.IdEstado== body.IdEstado).ToList();
           
            PedidoResponse respuesta = new PedidoResponse();
            respuesta.Count = pedidos.Count;
            respuesta.Items = pedidos.Select(p =>
            {
                return new PedidoDatos
                {
                    IdPedido = p.IdPedido,
                    IdCliente = p.IdCliente,
                    Estado = p.IdEstadoNavigation.Descripcion,
                    FechaModificacion = p.FechaModificacion,
                    ModificadoPor = new UsuarioDatos {
                        IdUsuario = p.ModificadoPorNavigation.IdUsuario,
                        Email = p.ModificadoPorNavigation.Email,
                        Nombre = p.ModificadoPorNavigation.Nombre,
                        Apellido = p.ModificadoPorNavigation.Apellido,
                        FechaNacimiento = p.ModificadoPorNavigation.FechaNacimiento,
                    },
                  //  Articulos = _servicesApiPedido.obtenerArticulosPedidoDatos(p)

                };
            });

            return respuesta;
        }

       
    }
}
