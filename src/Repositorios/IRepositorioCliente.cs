using ProgaWeb3TP.src.Entidades;
using System.Collections.Generic;

namespace Repositorios
{
    public interface IRepositorioCliente
    {
        void Guardar(Cliente cliente);
        List<Cliente> ObtenerClientes(); 
        Cliente ObtenerCliente(int id);
    }
}
