using GestorDePedidos.Entidades;

namespace Repositorios.Filtros.FiltrosUsuarios
{
    public class FiltroPorDadoDeBaja : IFiltroUsuario
    {
        public bool Evaluar(Usuario usuario)
        {
            return usuario.FechaBorrado == null;
        }
    }
}
