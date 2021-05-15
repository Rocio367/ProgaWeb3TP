using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelos
{
    public static class Datos
    {
        public static List<Articulo> Articulos = new List<Articulo>();


        static Datos()
        {
            Articulo art1 = new Articulo();
            art1.IdArticulo = 1;
            art1.Codigo = "1";
            art1.Descripcion = "Heladera";
            Articulo art2 = new Articulo();
            art2.IdArticulo = 2;
            art2.Codigo = "2";
            art2.Descripcion = "TV";
            Articulo art3 = new Articulo();
            art3.IdArticulo = 3;
            art3.Codigo = "3";
            art3.Descripcion = "Cama";
            Articulos.Add(art1);
            Articulos.Add(art2);
            Articulos.Add(art3);
        



        }

        public static void AgregarArticulo(Articulo art)
        {
            art.IdArticulo = Articulos.Max(d => d.IdArticulo);
            Articulos.Add(art);

        }
    }
}
