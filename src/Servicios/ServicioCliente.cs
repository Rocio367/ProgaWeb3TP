using DTOs;
using Modelos;
using Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        private IRepositorioCliente _repositorioCliente;
        public ServicioCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        } 
        public void Guardar(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Numero = clienteDTO.Numero ?? 0, //Aca iria la logica de generar un numero de cliente
                Email = clienteDTO.Email,
                Telefono = clienteDTO.Telefono,
                Direccion = clienteDTO.Direccion,
                CUIT = clienteDTO.Cuit
            };
            _repositorioCliente.Guardar(cliente);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            List<Cliente> clientes = _repositorioCliente.ObtenerClientes();
            return clientes.Select(cliente =>            
                new ClienteDTO
                {
                    Nombre = cliente.Nombre,
                    Numero = cliente.Numero,
                    Email = cliente.Email,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    Cuit = cliente.CUIT
                }
            ).ToList();
        }
    }
}
