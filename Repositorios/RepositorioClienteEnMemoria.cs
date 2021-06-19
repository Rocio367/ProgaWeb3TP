using GestorDePedidos.Entidades;
using System.Collections.Generic;

namespace Repositorios
{
    public class RepositorioClienteEnMemoria : IRepositorioCliente
    {
        private List<Cliente> _clientes;
        private int _proximoNumeroDeCliente = 1;

        public RepositorioClienteEnMemoria()
        {
           _clientes = new List<Cliente>();
            Cliente c1 = new Cliente
            {
                Nombre = "Jose",
                Email = "jose@hotmail.com",
                Telefono = "44543215",
                Direccion = "almafuerte 5152",
                Cuit = "20-94507958-5"
            };
            _clientes.Add(c1);
        }
        public void Guardar(Cliente cliente)
        {
            cliente.IdCliente = cliente.Numero = _proximoNumeroDeCliente;
            _clientes.Add(cliente);

            _proximoNumeroDeCliente++;
        }

        public Cliente ObtenerCliente(int id)
        {
            return _clientes.Find(cliente => cliente.IdCliente.Equals(id));
        }

    public List<Cliente> ObtenerClientes()
        {
            return _clientes;
        }
    public void Actualizar()
        {
            
        }
    }
}
