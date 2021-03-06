using System.Collections.Generic;
using GestorDePedidos.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;
using Repositorios.Filtros.FiltrosUsuarios;

namespace Repositorios
{
    public interface IRepositorioUsuario
    {
        void Guardar(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuario(int id);
        Usuario ObtenerUsuarioPorMail(string mail);
        void EliminarUsuario(Usuario usuario);
        bool ValidarLogin(Usuario usuario);
        void EditarHora(string email);
        List<Usuario> ObtenerUsuariosPorFiltro(IFiltroUsuario filtro);
        public List<Usuario> ObtenerUsuariosParaFiltro();
        int ContarUsuariosConMail(string mail);
    }
}
