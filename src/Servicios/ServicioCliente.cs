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
                Email = clienteDTO.Email,
                Telefono = clienteDTO.Telefono,
                Direccion = clienteDTO.Direccion,
                CUIT = clienteDTO.Cuit
            };
            _repositorioCliente.Guardar(cliente);
        }

        public ClienteDTO ObtenerCliente(int id)
        {
            Cliente cliente =  _repositorioCliente.ObtenerCliente(id);
            return ConvertirEnDTO(cliente);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            List<Cliente> clientes = _repositorioCliente.ObtenerClientes();
            return clientes.Select(cliente => ConvertirEnDTO(cliente)).ToList();
        }

        private static ClienteDTO ConvertirEnDTO(Cliente cliente)
        {
            return new ClienteDTO
            {   IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Numero = cliente.Numero,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Cuit = cliente.CUIT
            };
        }

        public void Editar(int id, ClienteDTO clienteDTO)
        {
            List<Cliente> clientes = _repositorioCliente.ObtenerClientes();
            foreach (Cliente cliente in clientes)
            {
                if(id == cliente.IdCliente)
                {
                    cliente.Nombre = clienteDTO.Nombre;
                    cliente.Numero = (int)clienteDTO.Numero;
                    cliente.Email = clienteDTO.Email;
                    cliente.Telefono = clienteDTO.Telefono;
                    cliente.Direccion = clienteDTO.Direccion;
                    cliente.CUIT = clienteDTO.Cuit;
                }
            }
        }

        public void Eliminar(int id)
        {
            List<Cliente> clientes = _repositorioCliente.ObtenerClientes();
            foreach (Cliente cliente in clientes)
            {
                if (id == cliente.IdCliente)
                {
                    clientes.Remove(cliente);
                    break; //una vez encontrado el cliente sale del ciclo ..caso contrario vuelve a buscar y tira error por que la lista fue modificada
                }
            }
        }
    }
}
