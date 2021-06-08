using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PagedList;


namespace ProgaWeb3TP.Controllers
{
    public class PedidoController : BaseController
    {
        // GET: PedidoController1
        public ActionResult Lista()
        {
<<<<<<< Updated upstream
            return View();
=======
            _servicioPedido = servicioPedido;
        }

        public ActionResult Lista()
        {
            ListaPedidosVM model = new ListaPedidosVM();
            model.pedidos = this._servicioPedido.ObtenerPedidosSinFiltro().ToPagedList(1, 10);
            model.estados = this._servicioPedido.ObtenerEstados();
            model.clientes = this._servicioPedido.ObtenerClientes();
          
            ViewBag.page = 1;

            return View(model);
        }
        public ActionResult Filtrar(int id_cliente, int estado, Boolean eliminados = true, int? page = 1)
        {
            ListaPedidosVM model = new ListaPedidosVM();
            model.id_cliente = id_cliente;
            model.id_estado = estado;
            model.eliminados = eliminados;
            model.pedidos = this._servicioPedido.ObtenerPedidosConFiltro(id_cliente, estado, eliminados).ToPagedList(page.Value, 10);
            model.estados = this._servicioPedido.ObtenerEstados();
            model.clientes = this._servicioPedido.ObtenerClientes();

            ViewBag.page = page;

            return View(model);
>>>>>>> Stashed changes
        }
        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
       

        // POST: PedidoController1/Create
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

        // GET: PedidoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController1/Edit/5
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

        // GET: PedidoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController1/Delete/5
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
