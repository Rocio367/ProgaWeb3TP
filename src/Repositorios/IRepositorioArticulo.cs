
using ProgaWeb3TP.ContextBD;
using System;
using System.Collections.Generic;

namespace Repositorios
{
    public interface IRepositorioArticulo
    {
        void Guardar(Articulo articulo);
        void Editar(Articulo articulo);
        void Eliminar(int id);
        Articulo ObtenerArticulo(int id);

        List<Articulo> ObtenerArticulosSinFiltro();
        List<Articulo> ObtenerArticulosConFiltro(string nombre, string number, Boolean eliminados);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();
    }
}
