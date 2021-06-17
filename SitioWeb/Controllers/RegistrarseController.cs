using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDePedidos.Controllers
{
    public class RegistrarseController : BaseController
    {
        // GET: RegistrarseController1
        public ActionResult Registrarse()
        {
            return View();
        }


        // POST: RegistrarseController1/Create
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

        // GET: RegistrarseController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrarseController1/Edit/5
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

        // GET: RegistrarseController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrarseController1/Delete/5
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
