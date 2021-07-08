using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Servicios
{
    class ServicioLogin : IServicioLogin
    {
        public bool ValidarLogin(UsuarioDTO user)
        {
            return false;
        }
    }
}
