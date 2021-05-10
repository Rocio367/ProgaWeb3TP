using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{

	public class UsuarioDTO

	{
		
	       [Required(ErrorMessage = "Ingrese un valor al campo email")]
			[EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]
			public string Email { get; set; }
			[Required(ErrorMessage = "Ingrese un valor al campo contraseña")]
			public string Password { get; set; }

		
	}
}