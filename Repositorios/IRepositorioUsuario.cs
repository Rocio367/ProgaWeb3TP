using System.Collections.Generic;
using GestorDePedidos.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
        void EliminarUsuario(Usuario usuario);
        bool ValidarLogin(Usuario usuario);
        void EditarHora(string email);
    }
}
