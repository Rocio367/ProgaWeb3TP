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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace ProgaWeb3TP.Controllers
{
    [Authorize(Roles = "Estandar")]
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

        public ActionResult Lista( int? id_cliente, Boolean eliminados = true, Boolean solo_ultimos_dos_meses = true, int page = 1, int? id_estado =1)
        {   

            ListaPedidoVM model = new ListaPedidoVM();


            model.id_estado = id_estado;
            model.id_cliente = id_cliente;
            model.eliminados = eliminados;
            model.solo_ultimos_dos_meses = solo_ultimos_dos_meses;
            model.pedidos = this._servicioPedido.ObtenerPedidosConFiltro(id_cliente, id_estado, eliminados, solo_ultimos_dos_meses).ToPagedList(page, _elementosPorPagina);

            model.estados = this._servicioPedido.ObtenerEstados();
            model.clientes = _servicioCliente.ObtenerClientes();

            ViewBag.page = page;

            return View("Lista", model);
        }


        [HttpPost]
        public ActionResult EliminarArticulo(CrearPedidoVM model, int idPedido, int idEliminar, string view)
        {
            model.Clientes = _servicioCliente.ObtenerClientesParaFiltro();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            List<PedidoArticuloDTO> PedidoArticulos = new List<PedidoArticuloDTO>();

            if (TempData["listaArticulosPedido"] != null)
            {
                PedidoArticulos =JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());
            }

            PedidoArticuloDTO aEliminar= PedidoArticulos.Find(d => d.Id== idEliminar);
            PedidoArticulos.Remove(aEliminar);
            TempData["listaArticulosPedido"]= JsonConvert.SerializeObject(PedidoArticulos);
            model.pedido.PedidoArticulos = PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList();

            if (view == "Crear")
            {
                return View("Crear", model);
            }
            else
            {
                return Redirect("Editar/" + idPedido);
            }
        }

        [HttpPost]
        public ActionResult AgregarArticulo(CrearPedidoVM model,int articuloId, int idPedido, int cantidad, string view ) {
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            List<PedidoArticuloDTO> PedidoArticulos = new List<PedidoArticuloDTO>();

            if (TempData["listaArticulosPedido"] != null)
            {
                PedidoArticulos =JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());

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
              
                } else {
               
                CrearNotificacionDeError("Debe seleccionar un aticulo y una cantidad mayor a 0");

            }
          
            model.pedido.PedidoArticulos = PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList();
            TempData["listaArticulosPedido"] = JsonConvert.SerializeObject(PedidoArticulos);
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
            TempData["listaArticulosPedido"] = null;

            return View(model);
        }
        [HttpPost]

        public ActionResult Crear(CrearPedidoVM model){
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (TempData["listaArticulosPedido"] != null)
            {
                model.pedido.PedidoArticulos =JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());
            }
            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
                {
                var nombreCliente = _servicioPedido.ExistePedidoAbiertoPorCliente(model.pedido.idCliente);
                if (nombreCliente == "") {
                    int idUsuario =Int32.Parse( HttpContext.Session.GetString("id"));
                    model.pedido.CreadoPor = idUsuario;
                    int nroPedido = this._servicioPedido.Guardar(model.pedido);
                    CrearNotificacionExitosa("Pedido " + nroPedido + " fue creado  correctamente");
                    TempData["listaArticulosPedido"]=null;
                    return RedirectToAction("Lista", "Pedido");

                }
                else {
                    model.pedido.PedidoArticulos = model.pedido.PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList();
                    TempData["listaArticulosPedido"] = JsonConvert.SerializeObject(model.pedido.PedidoArticulos);
                    CrearNotificacionDeError("El cliente " + nombreCliente  + " ya posee otro pedido Abierto, modifique ese pedido");
                    return View(model);
                }

            }
                else
               {
                model.pedido.PedidoArticulos = model.pedido.PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList();
                TempData["listaArticulosPedido"] = JsonConvert.SerializeObject(model.pedido.PedidoArticulos);
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


            if (TempData["listaArticulosPedido"] != null)
            {
                model.pedido.PedidoArticulos =JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());
            }
            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
                {
                int idUsuario = Int32.Parse(HttpContext.Session.GetString("id"));
                model.pedido.CreadoPor = idUsuario;
                int nroPedido = this._servicioPedido.Guardar(model.pedido);
                    CrearNotificacionExitosa("Pedido " + nroPedido + " fue creado correctamente");
                TempData["listaArticulosPedido"] = null;
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


            if (TempData["listaArticulosPedido"] != null)
            {
                model.pedido.PedidoArticulos =  JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());
            }
            model.pedido.PedidoArticulos=model.pedido.PedidoArticulos.OrderBy(d => d.articulo.Codigo).ToList();
            TempData["listaArticulosPedido"] = JsonConvert.SerializeObject(model.pedido.PedidoArticulos);

            return View(model);
        }

        [HttpPost]

        public ActionResult Editar(CrearPedidoVM model)
        {
            model.Clientes = _servicioCliente.ObtenerClientes();
            model.Articulos = _servicioArticulo.ObtenerArticulosSinFiltro();
            model.pedido.PedidoArticulos = new List<PedidoArticuloDTO>();

            if (TempData["listaArticulosPedido"] != null)
            {
                model.pedido.PedidoArticulos =JsonConvert.DeserializeObject<List<PedidoArticuloDTO>>(TempData["listaArticulosPedido"].ToString());
            }

            if (ModelState.IsValid && model.pedido.PedidoArticulos.Count() > 0)
            {
                int idUsuario = Int32.Parse(HttpContext.Session.GetString("id"));
                 model.pedido.ModificadoPor = idUsuario;
                int nroPedido = this._servicioPedido.Editar(model.pedido);
                CrearNotificacionExitosa("Pedido " + nroPedido + " fue editado  correctamente");
                TempData["listaArticulosPedido"] = null;
                return RedirectToAction("Lista", "Pedido");
            }

            else
            {
                CrearNotificacionDeError("Complete corectamente el formulario para editar el pedido Pedido");
                return View(model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            string idUsuario = HttpContext.Session.GetString("id");
            this._servicioPedido.Eliminar(id, Int32.Parse(idUsuario));
            CrearNotificacionExitosa("El Pedido fue eliminado correctamente");
            return RedirectToAction("Lista", "Pedido");
        }

        public ActionResult Cerrar(int id)
        {
            string idUsuario = HttpContext.Session.GetString("id");

            this._servicioPedido.cambiarEstado(id,2,Int32.Parse(idUsuario));
            CrearNotificacionExitosa("El Pedido fue actualizado como 'Cerrado'");
            return RedirectToAction("Lista", "Pedido");
        }

        public ActionResult Entregado(int id)
        {
            string idUsuario = HttpContext.Session.GetString("id");
            this._servicioPedido.cambiarEstado(id, 3,Int32.Parse(idUsuario));
            CrearNotificacionExitosa("El Pedido fue actualizado como 'Entregado'");
            return RedirectToAction("Lista", "Pedido");
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Cancelar()
        {

            return RedirectToAction("Lista", "Pedido");
        }
    }
}
