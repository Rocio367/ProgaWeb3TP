using DTOs;
using Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        public ActionResult Editar()
        {
            return View();
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
