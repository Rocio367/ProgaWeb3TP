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
        public void Guardar(ClienteDTO clienteDTO, UsuarioDTO administrador)
        {
            Cliente cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Email = clienteDTO.Email,
                Telefono = clienteDTO.Telefono,
                Direccion = clienteDTO.Direccion,
                Cuit = clienteDTO.Cuit,
                CreadoPor = administrador.IdUsuario,
                FechaCreacion = DateTime.UtcNow
            };
            _repositorioCliente.Guardar(cliente);
        }

        public ClienteDTO ObtenerCliente(int id)
        {
            Cliente cliente = _repositorioCliente.ObtenerCliente(id);
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
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Numero = cliente.Numero,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Cuit = cliente.Cuit,
                EstaEliminado = cliente.FechaBorrado != null
            };
        }

        public void Editar(ClienteDTO clienteDTO, UsuarioDTO administrador)
        {
            Cliente cliente = _repositorioCliente.ObtenerCliente(clienteDTO.IdCliente);

            cliente.Nombre = clienteDTO.Nombre;
            cliente.Numero = clienteDTO.Numero.Value;
            cliente.Email = clienteDTO.Email;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.Direccion = clienteDTO.Direccion;
            cliente.Cuit = clienteDTO.Cuit;
            cliente.ModificadoPor = administrador.IdUsuario;
            cliente.FechaModificacion = DateTime.UtcNow;

            _repositorioCliente.Actualizar();
        }

        public ClienteDTO Eliminar(int idCliente, UsuarioDTO administrador)
        {
            Cliente cliente = _repositorioCliente.ObtenerCliente(idCliente);
            cliente.BorradoPor = administrador.IdUsuario;
            cliente.FechaBorrado = DateTime.UtcNow;
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

        public List<ClienteDTO> ObtenerClientesParaFiltro()
        {
                List<Cliente> clientes = _repositorioCliente.ObtenerClientesParaFiltro();
                return clientes.Select(cli =>
                    new ClienteDTO
                    {
                        IdCliente = cli.IdCliente,
                        Nombre = cli.Nombre,


                    }
                ).ToList();
            

        }
    }
}
