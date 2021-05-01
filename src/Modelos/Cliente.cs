using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Cliente
    {
		public int IdCliente { set; get; }
		public int Numero { set; get; }
		public string Nombre { set; get; }
		public string Telefono { set; get; }
		public string Email { set; get; }
		public string Direccion { set; get; }
		public string CUIT { set; get; }
		public DateTime FechaCreacion { set; get; }
		public DateTime FechaBorrado { set; get; }
		public DateTime FechaModifica { set; get; }
		public Usuario CreadoPor { set; get; }
		public Usuario ModificadoPor { set; get; }
		public Usuario BorradoPor { set; get; }

    }
}
