using Modelos;
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

        List<Articulo> ObtenerArticulos(string nombre, string number, Boolean? eliminados);
        List<string> ObtenerDescripciones();
        List<string> ObtenerCodigos();
    }
}
