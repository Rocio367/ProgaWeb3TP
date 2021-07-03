using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class FiltroUsuario
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public bool ExcluirEliminados { get; set; }
    }
}
