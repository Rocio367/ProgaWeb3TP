using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Servicios;
using Microsoft.AspNetCore.Authorization;
namespace GestorDePedidos.Controllers
{
    public class LoginController : BaseController
    {
        private IServicioLogin _servicioLogin;
        private IServicioUsuario _servicioUsuario;

        // GET: LoginController
        [AllowAnonymous]
        public ActionResult login()
        {
            return View(new UsuarioDTO());
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UsuarioDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool resul = _servicioUsuario.ValidarLogin(user);
                    if (resul)
                    {
                        this._servicioUsuario.EditarHora(user.Email);

                        return View("~/Views/Pedido/Lista.cshtml");
                    }
                    else
                    {
                        ViewBag.ErrorMessageLogin = "el usuario y/o contraseña  son invalidos";
                        return View("~/Views/Login/Login.cshtml", user);
                    }

                }
                else
                {
                    ViewBag.ErrorMessageLogin = "Ingrese usuario y/o contraseña.";
                    return View("~/Views/Login/Login.cshtml", user);
                }
            }
            catch
            {
                return View("~/Views/Pedido/Lista.cshtml");
            }
        }


        public ActionResult Logout()
        {
            // eliminar datos de session
            //control.eliminarSession();
            return View("~/Views/Login/Login.cshtml", new UsuarioDTO());
        }




        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
