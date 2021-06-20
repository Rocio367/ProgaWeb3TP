using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros
{
    public class FiltroPorNombreCliente : IFiltroCliente
    {
        private string _nombre;
        public FiltroPorNombreCliente(string nombre)
        {
            _nombre = nombre;
        }
        public bool Evaluar(Cliente cliente)
        {
            return cliente.Nombre == _nombre;
        }
    }
}
