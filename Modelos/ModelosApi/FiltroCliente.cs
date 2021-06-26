using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class FiltroCliente
    {
        public string? Nombre { get; set; }
        public int? Numero { get; set; }
        public bool ExcluirEliminados { get; set; }
    }
}
