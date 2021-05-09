﻿using DTOs;
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
            {
                Nombre = cliente.Nombre,
                Numero = cliente.Numero,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Cuit = cliente.CUIT
            };
        }
    }
}
