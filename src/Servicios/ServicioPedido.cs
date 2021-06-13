using DTOs;
using ProgaWeb3TP.src.Entidades;
using ProgaWeb3TP.src.Repositorios;
using Repositorios;
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
        private IServicioArticulo _servicioArticulo;
        public ServicioPedido(IRepositorioPedido repositorioPedido, IServicioArticulo servicioArticulo)
        {
            _repositorioPedido = repositorioPedido;
            _servicioArticulo = servicioArticulo;
        }
        public int Editar(PedidoDTO pedido)
        {
            Pedido ped = new Pedido
            {
                IdCliente = pedido.idCliente,
                Comentarios = pedido.Comentarios,
                IdPedido = pedido.IdPedido,
                IdEstado=pedido.IdEstado,
                NroPedido=pedido.NroPedido
            };

            pedido.PedidoArticulos.ForEach(d =>
            {
                ped.PedidoArticulos.Add(new PedidoArticulo
                {
                    IdArticulo = d.articulo.Id,
                    Cantidad = d.cantidad
                });
            });

            return _repositorioPedido.Editar(ped);
        }

        public void Eliminar(int id)
        {
            _repositorioPedido.Eliminar(id);
        }
        public int cambiarEstado(int idPedido, int idEstado) {
            return _repositorioPedido.cambiarEstado(idPedido,idEstado);
        }
        public int Guardar(PedidoDTO pedido)
        {
        

         Pedido ped = new Pedido
            {
                IdCliente = pedido.idCliente,
                Comentarios=pedido.Comentarios,
            };

            pedido.PedidoArticulos.ForEach(d =>
            {
                ped.PedidoArticulos.Add(new PedidoArticulo {
                    IdArticulo = d.articulo.Id,
                    Cantidad=d.cantidad
                }) ;
            });
            
           return  _repositorioPedido.Guardar(ped);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            List<Cliente> clientes = _repositorioPedido.ObtenerClientes();
            return clientes.Select(cli =>
                new ClienteDTO
                {
                    IdCliente = cli.IdCliente,
                    Nombre = cli.Nombre,
                   

                }
            ).ToList();
        }
        public List<ClienteDTO> ObtenerClientesFiltro() {
            List<Cliente> clientes = _repositorioPedido.ObtenerClientesFiltro();
            return clientes.Select(cli =>
                new ClienteDTO
                {
                    IdCliente = cli.IdCliente,
                    Nombre = cli.Nombre,


                }
            ).ToList();
        }
        public List<EstadoPedidoDTO> ObtenerEstados()
        {
            List<EstadoPedido> estados = _repositorioPedido.ObtenerEstados();
            return estados.Select(est =>
                new EstadoPedidoDTO
                {
                    IdEstadoPedido = est.IdEstadoPedido,
                    Descripcion = est.Descripcion,


                }
            ).ToList();
        }

        public PedidoDTO ObtenerPedido(int id)
        {
            //fijarse si falta algun dato
            Pedido ped = this._repositorioPedido.ObtenerPedido(id);
            PedidoDTO pedidoDTO = new PedidoDTO
            {
                IdPedido = ped.IdPedido,
                idCliente = ped.IdCliente,
                IdEstado = ped.IdEstado,
                FechaCreacion = ped.FechaCreacion,
                FechaModificacion = ped.FechaModificacion,
                NroPedido = ped.NroPedido,
                Comentarios=ped.Comentarios,
                IdClienteNavigation = new ClienteDTO
                {
                    IdCliente = ped.IdClienteNavigation.IdCliente,
                    Nombre = ped.IdClienteNavigation.Nombre
                },
                IdEstadoNavigation = new EstadoPedidoDTO
                {
                    IdEstadoPedido = ped.IdEstadoNavigation.IdEstadoPedido,
                    Descripcion = ped.IdEstadoNavigation.Descripcion
                },
                ModificadoPorNavigation = (ped.ModificadoPor != null) ? new UsuarioDTO
                {
                    IdUsuario = ped.ModificadoPorNavigation.IdUsuario,
                    Nombre = ped.ModificadoPorNavigation.Nombre,
                    Apellido = ped.ModificadoPorNavigation.Apellido
                } : new UsuarioDTO(),

            };
            pedidoDTO.PedidoArticulos = new List<PedidoArticuloDTO>();
            int index = 0;
            ped.PedidoArticulos.ToList().ForEach(d =>
            {
                pedidoDTO.PedidoArticulos.Add(new PedidoArticuloDTO
                {
                    Id=index,
                    articulo = _servicioArticulo.ObtenerArticulo(d.IdArticulo),
                    cantidad = d.Cantidad
                });
                index ++;
            });
            return pedidoDTO;
        }

        public List<PedidoDTO> ObtenerPedidosConFiltro(int? id_cliente, int? id_estado, bool eliminados, Boolean ult_meses)
        {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosConFiltro(id_cliente,id_estado,eliminados,ult_meses);
            return pedidos.Select(ped =>
                new PedidoDTO
                { 
                    IdPedido= ped.IdPedido,
                    idCliente=ped.IdCliente,
                    IdEstado = ped.IdEstado,
                    FechaCreacion = ped.FechaCreacion,
                    FechaModificacion = ped.FechaModificacion,
                    NroPedido = ped.NroPedido,
                    IdClienteNavigation = new ClienteDTO
                    {
                        IdCliente = ped.IdClienteNavigation.IdCliente,
                        Nombre = ped.IdClienteNavigation.Nombre
                    },
                    IdEstadoNavigation = new EstadoPedidoDTO
                    {
                        IdEstadoPedido = ped.IdEstadoNavigation.IdEstadoPedido,
                        Descripcion = ped.IdEstadoNavigation.Descripcion
                    },

                    ModificadoPorNavigation = (ped.ModificadoPor!= null)? new UsuarioDTO
                    {
                        IdUsuario = ped.ModificadoPorNavigation.IdUsuario,
                        Nombre = ped.ModificadoPorNavigation.Nombre,
                        Apellido = ped.ModificadoPorNavigation.Apellido
                    } : new UsuarioDTO(),
                }
            ).ToList();
        }

        public List<PedidoDTO> ObtenerPedidosSinFiltro()
        {
            List<Pedido> pedidos = _repositorioPedido.ObtenerPedidosSinFiltro();
            return pedidos.Select(ped =>
                new PedidoDTO
                {
                    IdPedido = ped.IdPedido,
                    idCliente = ped.IdCliente,
                    IdEstado = ped.IdEstado,
                    FechaCreacion = ped.FechaCreacion,
                    IdClienteNavigation=new ClienteDTO {
                        IdCliente=ped.IdClienteNavigation.IdCliente,
                        Nombre=ped.IdClienteNavigation.Nombre
                    },
                    IdEstadoNavigation = new EstadoPedidoDTO
                    {
                        IdEstadoPedido = ped.IdEstadoNavigation.IdEstadoPedido,
                        Descripcion = ped.IdEstadoNavigation.Descripcion
                    },
                    FechaModificacion = ped.FechaModificacion,
                    NroPedido = ped.NroPedido,
                    ModificadoPorNavigation = (ped.ModificadoPor != null) ? new UsuarioDTO
                    {
                        IdUsuario = ped.ModificadoPorNavigation.IdUsuario,
                        Nombre = ped.ModificadoPorNavigation.Nombre,
                        Apellido = ped.ModificadoPorNavigation.Apellido
                    } : new UsuarioDTO(),
                }
            ).ToList();
        }
    }
}
