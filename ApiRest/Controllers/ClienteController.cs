using API.Modelo;
using ApiRest.Modelo;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private _20211CTPContext _contexto;

        public ClientesController(_20211CTPContext context)
        {
            _contexto = context;
        }

        [HttpGet]
        public ClienteResponse Obtener()
        {
            List<Cliente> clientes = _contexto.Clientes.ToList();

            return ResponderConClientes(clientes);
        }

        [HttpPost("filtrar")]
        public ClienteResponse Filtrar(FiltroClienteRequest filtro)
        {
            List<Cliente> clientes = _contexto.Clientes
                                            .Where(c => EF.Functions.Like(c.Nombre, $"%{filtro.Filtro}%"))
                                            .ToList();

            return ResponderConClientes(clientes);
        }

        private ClienteResponse ResponderConClientes(List<Cliente> clientes)
        {
            ClienteResponse respuesta = new ClienteResponse();
            respuesta.Count = clientes.Count;
            respuesta.Items = clientes.Select(c =>
            {
                return new ClienteDatos
                {
                    IdCliente = c.IdCliente,
                    Numero = c.Numero,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono
                };
            });

            return respuesta;
        }
    }
}
