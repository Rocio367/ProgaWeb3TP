using GestorDePedidos.Entidades;
using System.Collections.Generic;

namespace Repositorios
{
    public class RepositorioUsuarioEnMemoria : IRepositorioUsuario
    {
        private List<Usuario> _usuarios;
        private int _proximoNumeroDeUsuario = 1;

        public RepositorioUsuarioEnMemoria()
        {
            _usuarios = new List<Usuario>();
            Usuario u1 = new Usuario
            {
                Nombre = "Pedro",
                Apellido="Montiel",
                Email = "jose@hotmail.com",
                EsAdmin = true

            };
            _usuarios.Add(u1);
        }

        public void EditarUsuario(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public void EliminarUsuario(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Usuario usuario)
        {
            usuario.IdUsuario = usuario.IdUsuario= _proximoNumeroDeUsuario;
            _usuarios.Add(usuario);

            _proximoNumeroDeUsuario++;
        }

        public Usuario ObtenerUsuario(int id)
        {
            return _usuarios.Find(usuario => usuario.IdUsuario.Equals(id));
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

    }
}
