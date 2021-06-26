using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Filtros.FiltrosArticulo
{
    public class FiltroPorNumeroArticulo: IFiltroArticulo
    {
        private string _numero;
        public FiltroPorNumeroArticulo(string numero)
        {
            _numero = numero;
        }
        public bool Evaluar(Articulo articulo)
        {
            return articulo.Codigo == _numero;
        }
    }
}
