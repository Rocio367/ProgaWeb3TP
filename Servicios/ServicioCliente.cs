using DTOs;
using GestorDePedidos.Entidades;
using Repositorios;
using Repositorios.Filtros;
using System;
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
                Cuit = clienteDTO.Cuit
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
                Cuit = cliente.Cuit
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
                    cliente.Cuit = clienteDTO.Cuit;
                }
            }
        }

        public ClienteDTO Eliminar(int id)
        {
            Cliente cliente = _repositorioCliente.ObtenerCliente(id);
            cliente.FechaBorrado = DateTime.Now;
            _repositorioCliente.Actualizar();
            return ConvertirEnDTO(cliente);
        }

        public List<ClienteDTO> ObtenerClientesPorFiltro(string nombre, int? numero, bool excluirEliminados)
        {
            FiltroCompuestoDeClientes filtro = new FiltroCompuestoDeClientes();
            if (excluirEliminados == true)
            {
                filtro.Agregar(new FiltroPorDadoDeBaja());
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                filtro.Agregar(new FiltroPorNombreCliente(nombre));
            }

            if (numero != null)
            {
                filtro.Agregar(new FiltroPorNumeroCliente(numero.Value));
            }

            List<Cliente> clientes = null;
            if (filtro.TieneFiltros())
            {
                clientes = _repositorioCliente.ObtenerClientePorFiltro(filtro);
            }
            else
            {
                clientes = _repositorioCliente.ObtenerClientes();
            }

            return clientes.Select(cliente => ConvertirEnDTO(cliente)).ToList();
        }

        public bool ExisteCliente(int id)
        {
            if (_repositorioCliente.ObtenerCliente(id) != null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
