using ProgaWeb3TP.ContextBD;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgaWeb3TP.src.Repositorios
{
    public interface IRepositorioPedido
    {

namespace Repositorios
{
    public interface IRepositorioPedido
    {
        List<EstadoPedido> ObtenerEstados();
        List<Cliente> ObtenerClientes();
        List<Pedido> ObtenerPedidosSinFiltro();
        List<Pedido> ObtenerPedidosConFiltro(int id_cliente, int estado, bool eliminados);

    }
}
