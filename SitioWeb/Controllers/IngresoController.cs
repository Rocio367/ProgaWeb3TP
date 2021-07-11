using DTOs;
using GestorDePedidos.Entidades;
using GestorDePedidos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public ActionResult login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("Login", new UsuarioDTO());
        }
        public ActionResult Denegado(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: IngresoController/Create
        [HttpPost]
        public async Task<ActionResult> loginUsuario(UsuarioDTO usuario, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
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
                    TempData["Mensaje"] = null;
                    var claims = new List<Claim>();
                    claims.Add(new Claim("nombre", usuarioObt.Nombre));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, usuarioObt.Nombre));
                    if (usuarioObt.EsAdmin)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                        claims.Add(new Claim(ClaimTypes.Role, "Estandar"));
                        HttpContext.Session.SetString("rolUsuario", "Admin");
                }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Estandar"));
                    HttpContext.Session.SetString("rolUsuario", "Estandar");
                }
                    
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Lista", "Pedido");

                TempData["Mensaje"] = "Error al ingresar a la pagina. Email y/o Contraseña es invalido";
                return View("login");
                
            }
            else
            {
                TempData["Mensaje"] = $"Email y/o Contraseña inválidos";
                return RedirectToAction("login");
            }
        }

        [Authorize]
        public async Task<ActionResult> logout()
        {
            // HttpContext.Current.Session.Remove("usuario");
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
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
