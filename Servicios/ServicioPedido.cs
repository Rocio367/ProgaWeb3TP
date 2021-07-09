using DTOs;
using GestorDePedidos.Entidades;
using Modelos.ModelosApi;
using Repositorios;
using Repositorios.Filtros.FiltrosPedido;
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
                FechaBorrado = ped.FechaBorrado,
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
            FiltroCompuestoDePedido filtro = new FiltroCompuestoDePedido();
            if (eliminados == true)
            {
                filtro.Agregar(new FiltroDadoDeBajaPedido());
            }
            if (ult_meses == true)
            {
                filtro.Agregar(new FiltroDosUltimosMeses());
            }
            if (id_cliente!= null)
            {
                filtro.Agregar(new FiltroPorIdClinte(id_cliente));
            }
            if (id_estado != null && id_estado >= 0)
            {
                filtro.Agregar(new FiltroPorIdEstado(id_estado));
            }

            List<Pedido> pedidos = null;
            if (filtro.TieneFiltros())
            {
                pedidos = _repositorioPedido.ObtenerPedidosConFiltro(filtro);
            }
            else
            {
                pedidos = _repositorioPedido.ObtenerPedidosSinFiltro();
            }
            return pedidos.Select(ped =>
                new PedidoDTO
                { 
                    IdPedido= ped.IdPedido,
                    idCliente=ped.IdCliente,
                    IdEstado = ped.IdEstado,
                    FechaCreacion = ped.FechaCreacion,
                    FechaModificacion = ped.FechaModificacion,
                    FechaBorrado = ped.FechaBorrado,

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
                    FechaBorrado = ped.FechaBorrado,

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
        ///services para API REST

        public PedidoResponse BuscarPedidoApi(PedidoRequest body)
        {
            return _repositorioPedido.BuscarPedidoApi(body);
        }

        public MensajeResponse GuardarPedidoApi(GuardarPedidoRequest body) {
            MensajeResponse msg = new MensajeResponse();
            Pedido ped = new Pedido
            {
                IdCliente = body.IdCliente,
                ModificadoPor=body.ModificadoPor.IdUsuario,
                //IdPedido=body.IdPedido

            };

            body.Articulos.ForEach(d =>
            {
                ped.PedidoArticulos.Add(new PedidoArticulo
                {
                    IdArticulo = d.IdArticulo,
                    Cantidad = d.Cantidad
                });
            });
            int idPedido=_repositorioPedido.Guardar(ped);
            msg.Mensaje = "Pedido " + idPedido + " guardado con éxito";
            return msg;
        }

        public bool ExisteEstado(int id)
        {
            return _repositorioPedido.ExisteEstado(id);
        }

        public string ExistePedidoAbiertoPorCliente(int id)
        {
            return _repositorioPedido.ExistePedidoAbiertoPorCliente(id);
        }
    }
}
