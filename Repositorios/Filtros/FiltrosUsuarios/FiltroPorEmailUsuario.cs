using GestorDePedidos.Entidades;

namespace Repositorios.Filtros.FiltrosUsuarios
{
    public class FiltroPorEmailUsuario : IFiltroUsuario
    {
        private string _email;
        public FiltroPorEmailUsuario(string email)
        {
            _email = email;
        }
        public bool Evaluar(Usuario usuario)
        {
            return usuario.Email == _email;
        }
    }
}
