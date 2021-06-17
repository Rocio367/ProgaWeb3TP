using System.ComponentModel.DataAnnotations;
namespace DTOs
{
    public class ArticuloDTO
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50, ErrorMessage = "No se puede ingresar mas de 50 caracteres")]

        public string Codigo { set; get; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(300, ErrorMessage = "No se puede ingresar mas de 300 caracteres")]

        public string Descripcion { set; get; }
    }
}
