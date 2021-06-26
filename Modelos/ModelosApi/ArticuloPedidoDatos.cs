using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class ArticuloPedidoDatos
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
