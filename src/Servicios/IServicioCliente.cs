using DTOs;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioCliente
    {
        void Guardar(ClienteDTO clienteDTO);
        List<ClienteDTO> ObtenerClientes();
        ClienteDTO ObtenerCliente(int id);

        void Editar(int id, ClienteDTO clienteDTO);
    }
}
