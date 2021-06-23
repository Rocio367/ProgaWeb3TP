﻿using GestorDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositorioPedido
    {
        int Guardar(Pedido pedido);
        int Editar(Pedido pedido);
        void Eliminar(int id);
        Pedido ObtenerPedido(int id);
        int cambiarEstado(int idPedido, int idEstado);
        List<Pedido> ObtenerPedidosSinFiltro();
        List<Pedido> ObtenerPedidosConFiltro(int? id_cliente, int? id_estado, Boolean eliminados,Boolean ult_meses);
        List<Cliente> ObtenerClientes(); 
        List<Cliente> ObtenerClientesFiltro(); 
         List<EstadoPedido> ObtenerEstados();
    }
}
