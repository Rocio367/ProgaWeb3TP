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

        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual List<PedidoArticuloDTO> PedidoArticulos { get; set; }

    }
}
