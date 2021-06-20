using DTOs;
using Modelos;
using PagedList;
using System.Collections.Generic;

namespace SitioWeb.Models
{
    public class ListadoDeClientes
    {
        public FiltroCliente Filtro {get; set;}
        public IPagedList<ClienteDTO> Clientes { get; set; }
        public int NumeroPaginaActual { get; set; }
    }
}
