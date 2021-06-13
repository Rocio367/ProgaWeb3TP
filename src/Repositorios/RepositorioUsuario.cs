using ProgaWeb3TP.src.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    class RepositorioUsuario : IRepositorioUsuario
    {

        private _20211CTPContext _contexto;
        public RepositorioUsuario(_20211CTPContext contexto)
        {
            _contexto = contexto;
        }
        public void Guardar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _contexto.Usuarios.ToList();
        }
    }
}
