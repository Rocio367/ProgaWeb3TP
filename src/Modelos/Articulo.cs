using System;

namespace Modelos
{
    public class Articulo
    {
		public int IdArticulo { set; get; }
		public string Codigo { set; get; }
		public string Descripcion { set; get; }
		public DateTime FechaCreacion { set; get; }
		public DateTime FechaModifica{ set; get; }
		public DateTime FechaBorrado { set; get; }

		public Usuario CreadoPor { set; get; }
		public Usuario ModificadoPor { set; get; }
		public Usuario BorradoPor { set; get; }

	}
}
