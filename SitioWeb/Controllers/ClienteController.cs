﻿using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using Servicios;
using System;
using System.Collections.Generic;

namespace GestorDePedidos.Controllers
{
    public class ClienteController : BaseController
    {
        private IServicioCliente _servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        public ActionResult Lista(int? numeroPagina)
        {
            List<ClienteDTO> clientes = _servicioCliente.ObtenerClientes();
            int paginaPedida = numeroPagina ?? 1;
            var pagina = clientes.ToPagedList(paginaPedida, 3);
            
            ViewBag.Pagina = pagina;
            ViewBag.NumeroPaginaActual = paginaPedida;
            return View();
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
                CrearNotificacionExitosa($"El cliente {clienteDTO.Nombre} se ha creado correctamente");
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
                CrearNotificacionExitosa($"El cliente {clienteDTO.Nombre} se ha creado correctamente");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ClienteDTO clienteDTO)
        {
            _servicioCliente.Eliminar(clienteDTO.IdCliente);
            IActionResult vista = null;
            CrearNotificacionExitosa($"El cliente {clienteDTO.Nombre} se ha eliminado correctamente");
            vista = RedirectToAction("Lista", "Cliente");
            return vista;
        }
        // POST: ClienteController/Editar/idCliente a editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ClienteDTO clienteDTO)
        {
            IActionResult vista = null;

            if (ModelState.IsValid)
            {
                int id = clienteDTO.IdCliente;
                _servicioCliente.Editar(id,clienteDTO);
                vista = RedirectToAction("Lista", "Cliente");
            }
            else
            {
                vista = View("Editar", clienteDTO);
            }
            return vista;
        }
        
    }
}
