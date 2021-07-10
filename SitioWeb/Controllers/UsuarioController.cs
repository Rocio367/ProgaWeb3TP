using DTOs;
using Modelos.ModelosApi;
using Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using SitioWeb.Models;
using PagedList;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GestorDePedidos.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : BaseController
    {
        private IServicioUsuario _servicioUsuario;
        private int _elementosPorPagina;


        public UsuarioController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        {
            _servicioUsuario = servicioUsuario;
            _elementosPorPagina = configuration.GetValue<int>("ElementosPorPagina");
        }


        // GET: UsuarioController1
        public IActionResult Lista(int? numeroPagina, string nombre, string email, bool excluirEliminados)
        {
            FiltroUsuario filtro = new FiltroUsuario
            {
                Nombre = nombre,
                Email = email,
                ExcluirEliminados = excluirEliminados
            };
            List<UsuarioDTO> usuarios = _servicioUsuario.ObtenerUsuariosPorFiltro(nombre, email, excluirEliminados);
            int paginaPedida = numeroPagina ?? 1;
            return ListarUsuarios(filtro, usuarios, paginaPedida);
        }
        private IActionResult ListarUsuarios(FiltroUsuario filtro, List<UsuarioDTO> usuarios, int paginaPedida)
        {
            var pagina = usuarios.ToPagedList(paginaPedida, _elementosPorPagina);

            ListadoDeUsuarios modelo = new ListadoDeUsuarios
            {
                Filtro = filtro,
                Usuarios = pagina,
                NumeroPaginaActual = paginaPedida,
                UsuariosFiltro = _servicioUsuario.ObtenerUsuarios()
            };

            return View("Lista", modelo);
        }


        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(UsuarioDTO usuarioDTO)
        {
            IActionResult vista = null;
            if (ModelState.IsValid)
            {
                _servicioUsuario.Guardar(usuarioDTO);
                vista = RedirectToAction("Lista", "Usuario");
                CrearNotificacionExitosa($"El Usuario {usuarioDTO.Nombre} se ha creado correctamente");
            }
            else
            {
                vista = View("Crear");
                CrearNotificacionDeError("no es posible");
            }
            return vista;
        }

        public ActionResult Ver(int id)
        {
            System.Console.WriteLine("accion ver");
            UsuarioDTO usuario = _servicioUsuario.ObtenerUsuario(id);
            return View("Editar", usuario);
        }
        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuarioDTO)
        {
            IActionResult vista = null;
            if (ModelState.IsValid)
            {
                _servicioUsuario.Editar(usuarioDTO);
                vista = RedirectToAction("Lista", "Usuario");
            }
            else
            {
                vista = View("Editar", usuarioDTO);
            }
            return vista;
        }

        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Usuario usuarioDTO)
        {

            IActionResult vista = null;
            if (ModelState.IsValid)
            {
                _servicioUsuario.Eliminar(usuarioDTO);
                vista = RedirectToAction("Lista", "Usuario");
            }
            else
            {
                vista = View("Editar", usuarioDTO);
            }
            return vista;
        }




        // POST: UsuarioController1/Create
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

        // GET: UsuarioController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController1/Edit/5
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

        // GET: UsuarioController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController1/Delete/5
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