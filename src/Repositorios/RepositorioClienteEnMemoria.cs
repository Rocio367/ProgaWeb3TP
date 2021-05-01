using Modelos;
using System.Collections.Generic;

namespace Repositorios
{
    public class RepositorioClienteEnMemoria : IRepositorioCliente
    {
        private List<Cliente> _clientes;

        public RepositorioClienteEnMemoria()
        {
           _clientes = new List<Cliente>();
        }
        public void Guardar(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clientes;
        }
    }
}
