using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{

	public class UsuarioDTO

	{
		public int IdUsuario { set; get; }
		public Boolean EsAdmin { set; get; }
		public string Nombre { set; get; }
		public string Apellido { set; get; }
		public DateTime FechaNacimiento { set; get; }

		[Required(ErrorMessage = "Ingrese un valor al campo email")]
			[EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]
			public string Email { get; set; }
			[Required(ErrorMessage = "Ingrese un valor al campo contraseña")]
			public string Password { get; set; }

		
	}
}