using System;

namespace Modelos
{
    public class Usuario
    {
		public int IdUsuario { set; get; }
		public Boolean EsAdmin { set; get; }
		public string Nombre { set; get; }
		public string Apellido { set; get; }

		public string Password { set; get; }
		public string Email { set; get; }
	
		public DateTime FechaNacimiento { set; get; }
		public DateTime FechaUltLogin { set; get; }
		public DateTime FechaCreacion { set; get; }
		public DateTime FechaBorrado { set; get; }
		public DateTime FechaModifica { set; get; }
		public Usuario CreadoPor { set; get; }
		public Usuario ModificadoPor { set; get; }
		public Usuario BorradoPor { set; get; }
	

 
  
    }
}
