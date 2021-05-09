using Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioClienteEnMemoria : IRepositorioCliente
    {
        private List<Cliente> _clientes;
        private int _proximoNumeroDeCliente = 1;

        public RepositorioClienteEnMemoria()
        {
           _clientes = new List<Cliente>();
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
    }
}
