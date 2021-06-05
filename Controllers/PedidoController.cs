using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgaWeb3TP.Models;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.Controllers
{
    public class PedidoController : BaseController
    {
        private IServicioPedido _servicioPedido;

        public PedidoController(IServicioPedido servicioPedido)
        {
            _servicioPedido = servicioPedido;
        }

        public ActionResult Lista(int id_cliente, string estado, Boolean eliminados = true, int? page = 1)
        {
            ListaPedidosVM model = new ListaPedidosVM();
            model.id_cliente = id_cliente;
            model.estado = estado;
            model.eliminados = eliminados;
           /* model.pedidos = this._servicioPedido.ObtenerPedidos(id_cliente, estado, eliminados).ToPagedList(page.Value, 10);
            model.estados = this._servicioPedido.ObtenerEstados();
            model.clientes = this._servicioPedido.ObtenerClientes();
           */
            ViewBag.page = page;

            return View(model);
        }

        public ActionResult Crear()
        {

            return View();
        }
        public ActionResult Eliminar(int id)
        {
          /*  this._servicioPedido.Eliminar(id);
            CrearNotificacionExitosa("El pedido fue eliminado correctamente");*/
            return RedirectToAction("Lista", "Pedido");
        }
        [HttpPost]
        public ActionResult Crear(PedidoDTO ped)
        {
            try
             {

              /*   if (ModelState.IsValid)
                 {
                     this._servicioPedido.Guardar(ped);
                     CrearNotificacionExitosa("Articulo " + ped. + " fue creado con correctamente")

                     return RedirectToAction("Lista", "Articulo");

                 }
                 else
                 {
                     CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo articulo");

                 }*/
                 return View(ped);
        }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GuardarYCrearOtro(PedidoDTO ped)
        {
            try
            {
                /*  if (ModelState.IsValid)
                  {
                      this._servicioPedido.Guardar(ped);
                      CrearNotificacionExitosa("Pedido " + art.Descripcion + " fue creado con éxito");
                      art = null;
                  }
                  else
                  {
                      CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo pedido");
                  }*/
                return View("Crear", ped);
            }
            catch
            {
                return View("Crear");
            }
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
