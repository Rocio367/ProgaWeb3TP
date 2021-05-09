using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;

namespace ProgaWeb3TP.Controllers
{
    public class ClienteController : Controller
    {
        private IServicioCliente _servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        public ActionResult Lista()
        {
            List<ClienteDTO> clientes = _servicioCliente.ObtenerClientes();
            return View(clientes);
        }

        public ActionResult Crear()
        {
            return View();
        }
   

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            ClienteDTO cliente = _servicioCliente.ObtenerCliente(id);
            return View("Editar", cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(ClienteDTO clienteDTO)
        {
            IActionResult vista = null;

            if (ModelState.IsValid)
            {
                _servicioCliente.Guardar(clienteDTO);
                vista = RedirectToAction("Lista", "Cliente");
            }
            else
            {
                vista = View("Crear");
            }
            return vista;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarYCrearOtro(ClienteDTO clienteDTO)
        {
            IActionResult vista = null;

            if (ModelState.IsValid)
            {
                _servicioCliente.Guardar(clienteDTO);
                vista = RedirectToAction("Crear", "Cliente");
            }
            else
            {
                vista = View("Crear");
            }
            return vista;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelarCreacion()
        {
            return RedirectToAction("Lista", "Cliente");
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
