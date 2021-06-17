using System;
using DTOs;
using System.Collections.Generic;

namespace Servicios
{
    public interface IServicioArticulo
    {
        void Guardar(ArticuloDTO ArticuloDTO);
        void Editar(ArticuloDTO ArticuloDTO);
        void Eliminar(int id);
        List<ArticuloDTO> ObtenerArticulosConFiltro(string nombre, string number, Boolean eliminados);
        List<ArticuloDTO> ObtenerArticulosSinFiltro();
        ArticuloDTO ObtenerArticulo(int id);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();
    }
}
