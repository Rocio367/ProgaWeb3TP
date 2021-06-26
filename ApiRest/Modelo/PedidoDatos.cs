using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Modelo
{
    public class PedidoDatos
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public UsuarioDatos ModificadoPor { get; set; }

    
        public IEnumerable<ArticuloPedidoDatos> Articulos { get; set; }
    }
}
