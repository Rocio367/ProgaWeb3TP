
using GestorDePedidos.Entidades;
using Modelos.ModelosApi;
using Repositorios.Filtros.FiltrosArticulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositorioArticulo
    {
        void Guardar(Articulo articulo);
        void Editar(Articulo articulo);
        void Eliminar(int id);
        Articulo ObtenerArticulo(int id);

        List<Articulo> ObtenerArticulosSinFiltro();
        List<Articulo> ObtenerArticulosConFiltro(IFiltroArticulo filtro);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();

        ArticuloResponse ObtenerArticulosConFiltroApi(FiltroRequest filtro);

    }
}
