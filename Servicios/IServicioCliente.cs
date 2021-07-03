using DTOs;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioCliente
    {
        void Guardar(ClienteDTO clienteDTO);
        List<ClienteDTO> ObtenerClientes();
        ClienteDTO ObtenerCliente(int id);
        void Editar(int id, ClienteDTO clienteDTO);
        ClienteDTO Eliminar(int id);
        Boolean ExisteCliente(int id);
        public List<ClienteDTO> ObtenerClientesPorFiltro(string? Nombre, int? Numero, bool ExcluirEliminados);

        List<ClienteDTO> ObtenerClientesParaFiltro();
    }
}
