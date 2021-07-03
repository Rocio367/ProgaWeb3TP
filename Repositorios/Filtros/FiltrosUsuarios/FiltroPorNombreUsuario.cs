using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosUsuarios
{
    public class FiltroPorNombreUsuario : IFiltroUsuario
    {
        private string _nombre;
        public FiltroPorNombreUsuario(string nombre)
        {
            _nombre = nombre;
        }
        public bool Evaluar(Usuario usuario)
        {
            return usuario.Nombre.Contains(_nombre, System.StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
