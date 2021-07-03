using DTOs;
using Modelos;
using Modelos.ModelosApi;
using PagedList;
using System.Collections.Generic;

namespace SitioWeb.Models
{
    public class ListadoDeUsuarios
    {
        public FiltroUsuario Filtro { get; set; }
        public IPagedList<UsuarioDTO> Usuarios { get; set; }
        public int NumeroPaginaActual { get; set; }
        public List<UsuarioDTO> UsuariosFiltro { set; get; }

    }
}
