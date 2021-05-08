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

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ClienteDTO clienteDTO)
        {
            _servicioCliente.Guardar(clienteDTO);
            return RedirectToAction("Lista", "Cliente");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarYCrearOtro(ClienteDTO clienteDTO)
        {
            _servicioCliente.Guardar(clienteDTO);
            return RedirectToAction("Crear", "Cliente");
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
