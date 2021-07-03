using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelos;
using Modelos.ModelosApi;
using PagedList;
using Servicios;
using SitioWeb.Models;
using System;
using System.Collections.Generic;

namespace GestorDePedidos.Controllers
{
    public class ClienteController : BaseController
    {

        private IServicioCliente _servicioCliente;
        private int _elementosPorPagina;

        public ClienteController(IServicioCliente servicioCliente, IConfiguration configuration)
        {
            _servicioCliente = servicioCliente;
            _elementosPorPagina = configuration.GetValue<int>("ElementosPorPagina");
        }

        public IActionResult Lista(int? numeroPagina, string nombre, int? numero, bool excluirEliminados)
        {
            FiltroCliente filtro = new FiltroCliente
            {
                Nombre = nombre,
                Numero = numero,
                ExcluirEliminados = excluirEliminados
            };

            List<ClienteDTO> clientes = _servicioCliente.ObtenerClientesPorFiltro(nombre, numero, excluirEliminados);
            int paginaPedida = numeroPagina ?? 1;
            
            return ListarClientes(filtro, clientes, paginaPedida);
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
        
        private IActionResult ListarClientes(FiltroCliente filtro, List<ClienteDTO> clientes, int paginaPedida)
        {
            var pagina = clientes.ToPagedList(paginaPedida, _elementosPorPagina);

            ListadoDeClientes modelo = new ListadoDeClientes
            {
                Filtro = filtro,
                Clientes = pagina,
                NumeroPaginaActual = paginaPedida,
                ClientesFiltro = _servicioCliente.ObtenerClientes()
            };

            return View("Lista", modelo);
        }
    }
}
