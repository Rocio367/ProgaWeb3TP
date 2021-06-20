using GestorDePedidos.Entidades;
using Repositorios.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        private _20211CTPContext _contexto;
        public RepositorioClienteEF(_20211CTPContext contexto)
        {
            _contexto = contexto;
        }

        public void Guardar(Cliente cliente)
        {
            int ultimoNumeroCliente = _contexto.Clientes.Max(c => c.Numero);
            cliente.Numero = ultimoNumeroCliente + 1;
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public List<Cliente> ObtenerClientes()
        {
            return _contexto.Clientes.ToList();
        }
        public void Actualizar()
        {
            _contexto.SaveChanges();
        }
        public List<Cliente> ObtenerClientePorFiltro(IFiltroCliente filtro)
        {
            var resultado = _contexto.Clientes.Where(filtro.Evaluar).Select(cliente => cliente);
            return resultado.ToList();
        }
    }
}
