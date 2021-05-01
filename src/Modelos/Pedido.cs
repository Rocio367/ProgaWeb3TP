using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Pedido
    {
		public int IdPedido { set; get; }
		public Cliente IdCliente { set; get; }
		public EstadoPedido IdEstado { set; get; }
		public int NroPedido { set; get; }
		public string Comentarios { set; get; }
		public string Descripcion { set; get; }
		public DateTime FechaCreacion { set; get; }
		public DateTime FechaModifica { set; get; }
		public DateTime FechaBorrado { set; get; }

		public Usuario CreadoPor { set; get; }
		public Usuario ModificadoPor { set; get; }
		public Usuario BorradoPor { set; get; }

    }
}
