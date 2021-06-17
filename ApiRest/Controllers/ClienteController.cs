using API.Modelo;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    public class ClienteController : ApiController
    {
        private _20211CTPContext _contexto;

        public ClienteController(_20211CTPContext context)
        {
            _contexto = context;
        }

        [HttpGet("clientes")]
        public ClienteResponse Obtener()
        {
            var clientes = _contexto.Clientes.ToList();
            
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
