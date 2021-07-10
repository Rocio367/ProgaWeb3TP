using DTOs;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioCliente
    {
        void Guardar(ClienteDTO clienteDTO, UsuarioDTO administrador);
        List<ClienteDTO> ObtenerClientes();
        ClienteDTO ObtenerCliente(int id);
        void Editar(ClienteDTO clienteDTO, UsuarioDTO administrador);
        ClienteDTO Eliminar(int id, UsuarioDTO administrador);
        Boolean ExisteCliente(int id);
        public List<ClienteDTO> ObtenerClientesPorFiltro(string? Nombre, int? Numero, bool ExcluirEliminados);

        List<ClienteDTO> ObtenerClientesParaFiltro();
    }
}
