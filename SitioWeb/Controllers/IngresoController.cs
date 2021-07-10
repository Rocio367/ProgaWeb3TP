using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;

namespace SitioWeb.Controllers
{
    public class IngresoController : Controller
    {
        private IServicioUsuario _servicioUsuario;
        public IngresoController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }
        // GET: IngresoController
        public ActionResult login()
        {
            return View("Login", new UsuarioDTO());
        }


        // POST: IngresoController/Create
        [HttpPost]
        public ActionResult loginUsuario(UsuarioDTO usuario)
        {

            Boolean response = _servicioUsuario.ValidarLogin(usuario);
            if (response)
            {
                UsuarioDTO usuarioObt = _servicioUsuario.ObtenerUsuarioPorMail(usuario.Email);
                _servicioUsuario.EditarHora(usuario.Email);
                string nombreUsuario = usuarioObt.Nombre;
                int id = usuarioObt.IdUsuario;
                HttpContext.Session.SetString("nombre", nombreUsuario);
                HttpContext.Session.SetString("id", id.ToString());
                bool admin = usuarioObt.EsAdmin;
                HttpContext.Session.SetString("admin", admin.ToString());
                TempData["Mensaje"] = null;
                return RedirectToAction("Lista", "Usuario");
            }
            else
            {
                TempData["Mensaje"] = $"Email y/o Contraseña inválidos";
                return RedirectToAction("login");
            }
        }

        public ActionResult logout()
        {
            // HttpContext.Current.Session.Remove("usuario");
            HttpContext.Session.Clear();
            return RedirectToAction("login");

        }

        // POST: IngresoController/Edit/5
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

        // GET: IngresoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngresoController/Delete/5
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
