using DTOs.Validators;
using System.ComponentModel.DataAnnotations;
namespace DTOs
{
    public class ClienteDTO
    {
		public int? Numero { set; get; }
		[Required(ErrorMessage = "El campo Nombre es requerido")]
		public string Nombre { set; get; }
		public string Telefono { set; get; }
		public string Email { set; get; }
		public string Direccion { set; get; }
		[ValidadorCuit(ErrorMessage = "El CUIT ingresado es inválido")]
		public string Cuit { set; get; }
	}
}
