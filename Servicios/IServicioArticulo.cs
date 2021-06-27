using System;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ModelosApi;

namespace Servicios
{
    public interface IServicioArticulo
    {
        void Guardar(ArticuloDTO ArticuloDTO);
        void Editar(ArticuloDTO ArticuloDTO);
        void Eliminar(int id);
        List<ArticuloDTO> ObtenerArticulos(string nombre, string number, Boolean eliminados);
        List<ArticuloDTO> ObtenerArticulosSinFiltro();
        ArticuloDTO ObtenerArticulo(int id);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();

         ArticuloResponse ObtenerArticulosApi();

         ArticuloResponse FiltrarArticulosApi(FiltroRequest filtro);

    }
}
