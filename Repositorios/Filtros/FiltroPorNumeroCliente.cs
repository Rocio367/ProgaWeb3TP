using GestorDePedidos.Entidades;

namespace Repositorios.Filtros
{
    public class FiltroPorNumeroCliente : IFiltroCliente
    {
        private int _numero;
        public FiltroPorNumeroCliente(int numero)
        {
            _numero = numero;
        }
        public bool Evaluar(Cliente cliente)
        {
            return cliente.Numero == _numero;
        }
    }
}
