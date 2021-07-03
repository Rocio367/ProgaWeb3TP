using System;
using System.Collections.Generic;
using DTOs;
using GestorDePedidos.Entidades;

namespace Servicios
{
    public interface IServicioUsuario
    {
        List<UsuarioDTO> ObtenerUsuarios();
        void Guardar(UsuarioDTO usuarioDTO);
        UsuarioDTO ObtenerUsuario(int id);
        Boolean ExisteUsuario(int id);
        void Editar(Usuario usuario);
        void Eliminar(Usuario usuario);
        bool ValidarLogin(UsuarioDTO usuarioDTO);
        void EditarHora(string Email);
        public List<UsuarioDTO> ObtenerUsuariosPorFiltro(string? Nombre, string? Email, bool ExcluirEliminados);

        List<UsuarioDTO> ObtenerUsuariosParaFiltro();

    }
}
