using ProgaWeb3TP.src.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPedido : IServicioPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public ServicioPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
    }
}
