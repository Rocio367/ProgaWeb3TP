using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoDTO
    {

        public int IdPedido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int idCliente { get; set; }
        public int IdEstado { get; set; }
        public int NroPedido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(150, ErrorMessage = "No se puede ingresar mas de 150 caracteres")]

        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
        public int? BorradoPor { get; set; }

        public virtual ClienteDTO IdClienteNavigation { get; set; }
        public virtual EstadoPedidoDTO IdEstadoNavigation { get; set; }
        public virtual List<PedidoArticuloDTO> PedidoArticulos { get; set; }
        public virtual UsuarioDTO ModificadoPorNavigation { get; set; }

    }
}
