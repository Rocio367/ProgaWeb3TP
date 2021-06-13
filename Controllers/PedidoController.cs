using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgaWeb3TP.Models;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgaWeb3TP.src.Session;

namespace ProgaWeb3TP.Controllers
{
    public class PedidoController : BaseController
    {
        private IServicioPedido _servicioPedido;
        private IServicioArticulo _servicioArticulo;

        public PedidoController(IServicioPedido servicioPedido, IServicioArticulo servicioArticulo)
        {
            _servicioPedido = servicioPedido;
            _servicioArticulo = servicioArticulo;
        }
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Crear()
        {
            CrearPedidoVM model = new CrearPedidoVM();
            model.pedido = new PedidoDTO();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();
            model.Clientes=_servicioPedido.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);

            return View(model);
        }

        [HttpPost]
        public ActionResult EliminarArticulo(CrearPedidoVM model, int idEliminar)
        {
            model.Clientes = _servicioPedido.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            List<PedidoArticuloDTO> PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }

            PedidoArticuloDTO aEliminar= PedidoArticulos.Find(d => d.Id== idEliminar);
            PedidoArticulos.Remove(aEliminar);
            SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", PedidoArticulos);
            model.pedido.PedidoArticulos = PedidoArticulos;

            return View("Crear", model);
        }

        [HttpPost]
        public ActionResult AgregarArticulo(CrearPedidoVM model,int articuloId,int cantidad ) {
            model.Clientes = _servicioPedido.ObtenerClientes();
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
                }
                else {
                    pedidoArt.Id = PedidoArticulos.Max(d => d.Id) + 1;
                }
                PedidoArticulos.Add(pedidoArt);
                SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", PedidoArticulos);
              
                } else {
               
                CrearNotificacionDeError("Debe seleccionar un aticulo y una cantidad mayor a 0");

            }

          
            model.pedido.PedidoArticulos = PedidoArticulos;
           
            return View("Crear",model);
        }
        [HttpPost]

        public ActionResult Crear(CrearPedidoVM model){
            model.Clientes = _servicioPedido.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido") != null)
            {
                model.pedido.PedidoArticulos = SessionManager.Get<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido");
            }
            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
                {
                    int nroPedido=this._servicioPedido.Guardar(model.pedido);
                    CrearNotificacionExitosa("Pedido " + nroPedido + " fue creado  correctamente");
                    SessionManager.Set<List<PedidoArticuloDTO>>(HttpContext.Session, "listaArticulosPedido", null);
                    return RedirectToAction("Lista", "Pedido");

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
            model.Clientes = _servicioPedido.ObtenerClientes();
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

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Cancelar()
        {
            try
            {
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Editar()
        {
            return View();
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
