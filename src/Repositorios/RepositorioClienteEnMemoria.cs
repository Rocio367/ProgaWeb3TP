using Modelos;
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
        }
        public void Guardar(Cliente cliente)
        {
            cliente.Numero = _proximoNumeroDeCliente;
            _clientes.Add(cliente);

            _proximoNumeroDeCliente++;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clientes;
        }
    }
}
