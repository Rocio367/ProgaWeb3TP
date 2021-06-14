using DTOs;
using Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ProgaWeb3TP.src.Entidades;

namespace ProgaWeb3TP.Controllers
{
    public class UsuarioController : BaseController
    {
        private IServicioUsuario _servicioUsuario;

        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        // GET: UsuarioController1

        public ActionResult Lista()
        {
            List<UsuarioDTO> usuarios = _servicioUsuario.ObtenerUsuarios();
            return View(usuarios);
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
            if(ModelState.IsValid)
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
            if(ModelState.IsValid)
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
            System.Console.WriteLine("editar feo");
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
