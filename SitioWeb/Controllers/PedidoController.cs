using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using GestorDePedidos.Controllers;
using SitioWeb.Models;
using SitioWeb.Session;
using Microsoft.Extensions.Configuration;

namespace ProgaWeb3TP.Controllers
{
    public class PedidoController : BaseController
    {
        private IServicioPedido _servicioPedido;
        private IServicioArticulo _servicioArticulo;
        private IServicioCliente _servicioCliente;
        private int _elementosPorPagina;

        public PedidoController(IServicioPedido servicioPedido, IServicioCliente servicioCliente, IServicioArticulo servicioArticulo, IConfiguration configuration)
        {
            _servicioPedido = servicioPedido;
            _servicioArticulo = servicioArticulo;
            _servicioCliente = servicioCliente;
            _elementosPorPagina = configuration.GetValue<int>("ElementosPorPagina");
        }

        public ActionResult Lista( int? id_cliente, Boolean eliminados = true, Boolean solo_ultimos_dos_meses = true, int page = 1, string? id_estado = "Sin Filtro")
        {   

            ListaPedidoVM model = new ListaPedidoVM();

            int?  id_estado_int = Int32.TryParse(id_estado, out int resultEstado) ? resultEstado : 1;

            model.id_estado = id_estado_int;
            model.id_cliente = id_cliente;
            model.eliminados = eliminados;
            model.solo_ultimos_dos_meses = solo_ultimos_dos_meses;
            model.pedidos = this._servicioPedido.ObtenerPedidosConFiltro(id_cliente, id_estado_int, eliminados, solo_ultimos_dos_meses).ToPagedList(page, _elementosPorPagina);

            model.estados = this._servicioPedido.ObtenerEstados();
            model.clientes = _servicioCliente.ObtenerClientes();

            ViewBag.page = page;

            return View("Lista", model);
        }


        [HttpPost]
        public ActionResult EliminarArticulo(CrearPedidoVM model, int idPedido, int idEliminar)
        {
            model.Clientes = _servicioCliente.ObtenerClientesParaFiltro();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            List<PedidoArticuloDTO> PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }

            PedidoArticuloDTO aEliminar= PedidoArticulos.Find(d => d.Id== idEliminar);
            PedidoArticulos.Remove(aEliminar);
            SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList());
            model.pedido.PedidoArticulos = PedidoArticulos;

            return Redirect("Editar/"+ idPedido);
        }

        [HttpPost]
        public ActionResult AgregarArticulo(CrearPedidoVM model,int articuloId, int idPedido, int cantidad, string view ) {
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            List<PedidoArticuloDTO> PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }
            

            if (cantidad > 0 )
            {
               
                ArticuloDTO art = _servicioArticulo.ObtenerArticulo(articuloId);
                PedidoArticuloDTO pedidoArt = new PedidoArticuloDTO();
                pedidoArt.articulo = art;
                pedidoArt.cantidad = cantidad;
                if (PedidoArticulos.Count() == 0)
                {
                    pedidoArt.Id = 1;
                    PedidoArticulos.Add(pedidoArt);

                }
                else {
                    PedidoArticuloDTO artExistente = PedidoArticulos.Where(d => d.articulo.Id == articuloId).FirstOrDefault() ;
                    if (artExistente == null)
                    {
                        pedidoArt.Id = PedidoArticulos.Max(d => d.Id) + 1;
                        PedidoArticulos.Add(pedidoArt);

                    }
                    else {
                        artExistente.cantidad = artExistente.cantidad + cantidad;
                    }

                }
                SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList());
              
                } else {
               
                CrearNotificacionDeError("Debe seleccionar un aticulo y una cantidad mayor a 0");

            }
          
            model.pedido.PedidoArticulos = PedidoArticulos;
            if (view == "Crear") {
                return View("Crear", model);
             }
            else {
                return Redirect("Editar/" + idPedido);
            }
          
        }

        public ActionResult Crear()
        {
            CrearPedidoVM model = new CrearPedidoVM();
            model.pedido = new PedidoDTO();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);

            return View(model);
        }
        [HttpPost]

        public ActionResult Crear(CrearPedidoVM model){
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                model.pedido.PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }
            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
                {
                var nombreCliente = _servicioPedido.ExistePedidoAbiertoPorCliente(model.pedido.idCliente);
                if (nombreCliente == "") {
                    int nroPedido = this._servicioPedido.Guardar(model.pedido);
                    CrearNotificacionExitosa("Pedido " + nroPedido + " fue creado  correctamente");
                    SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);
                    return RedirectToAction("Lista", "Pedido");

                }
                else {
                    CrearNotificacionDeError("El cliente " + nombreCliente  + " ya posee otro pedido Abierto, modifique ese pedido");
                    return View(model);
                }

            }
                else
               {
                   
                    CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo Pedido");
                    return View(model);

                }          
           
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GuardarYCrearOtro(CrearPedidoVM model)
        {
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                model.pedido.PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }
            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
                {
                    int nroPedido = this._servicioPedido.Guardar(model.pedido);
                    CrearNotificacionExitosa("Pedido " + nroPedido + " fue creado correctamente");
                    SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);
                    return View("Crear", model);

                }
                else
                {             
                    CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo pedido");
                    return View("Crear", model);
                }         
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            CrearPedidoVM model = new CrearPedidoVM();
            model.pedido = _servicioPedido.ObtenerPedido(id);
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") == null)
            {
                SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", model.pedido.PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList());
            }

            else {
                model.pedido.PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }

            return View(model);
        }

        [HttpPost]

        public ActionResult Editar(CrearPedidoVM model)
        {
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                model.pedido.PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }

            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
            {
                int nroPedido = this._servicioPedido.Editar(model.pedido);
                CrearNotificacionExitosa("Pedido " + nroPedido + " fue editado  correctamente");
                SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);
                return RedirectToAction("Lista", "Pedido");
            }

            else
            {
                CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo Pedido");
                return View(model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            this._servicioPedido.Eliminar(id);
            CrearNotificacionExitosa("El Pedido fue eliminado correctamente");
            return RedirectToAction("Lista", "Pedido");
        }

        public ActionResult Cerrar(int id)
        {
            this._servicioPedido.cambiarEstado(id,2);
            CrearNotificacionExitosa("El Pedido fue actualizado como 'Cerrado'");
            return RedirectToAction("Lista", "Pedido");
        }

        public ActionResult Entregado(int id)
        {
            this._servicioPedido.cambiarEstado(id, 3);
            CrearNotificacionExitosa("El Pedido fue actualizado como 'Entregado'");
            return RedirectToAction("Lista", "Pedido");
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Cancelar()
        {
            return RedirectToAction("Lista", "Pedido");

        }

        // POST: PedidoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
