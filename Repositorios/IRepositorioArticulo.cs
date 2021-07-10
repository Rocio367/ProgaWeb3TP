
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
        void Eliminar(int id, int idUsuario);
        Articulo ObtenerArticulo(int id);

        List<Articulo> ObtenerArticulosSinFiltro();
        List<Articulo> ObtenerArticulosConFiltro(IFiltroArticulo filtro);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();
        Boolean ExisteArticulo(int id, string codigo, string descripcion);
        Boolean ExisteArticulo( string codigo, string descripcion);

        ArticuloResponse ObtenerArticulosConFiltroApi(FiltroRequest filtro);

    }
}
