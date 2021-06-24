﻿using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using ProgaWeb3TP.Models;
using GestorDePedidos.Controllers;
using SitioWeb.Models;

namespace ProgaWeb3TP.Controllers
{
    public class ArticuloController : BaseController
    { //
        private IServicioArticulo _servicioArticulo;

        public ArticuloController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }



    
        public ActionResult Lista(string nombre, string numero, Boolean eliminados = true, int? page = 1)
        {
            ListaAticulosVM model = new ListaAticulosVM();
            model.numero = numero;
            model.nombre = nombre;
            model.eliminados = eliminados;
            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(numero) && eliminados)
            {
                model.articulos = this._servicioArticulo.ObtenerArticulosSinFiltro().ToPagedList(page.Value, 10);

            }
            else {
                model.articulos = this._servicioArticulo.ObtenerArticulosConFiltro(nombre, numero, eliminados).ToPagedList(page.Value, 10);

            }
            model.nombres = this._servicioArticulo.ObtenerDescripciones();
            model.numeros = this._servicioArticulo.ObtenerCodigos();

            ViewBag.page = page;

            return View("Lista",model);
        }

        public ActionResult Crear()
        {

            return View(new ArticuloDTO());
        }
        public ActionResult Eliminar(int id)
        {
            this._servicioArticulo.Eliminar(id);
            CrearNotificacionExitosa("El articulo fue eliminado correctamente");
            return RedirectToAction("Lista", "Articulo");
        }
        [HttpPost]
        public ActionResult Crear(ArticuloDTO art)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._servicioArticulo.Guardar(art);
                    CrearNotificacionExitosa("Articulo " + art.Descripcion + " fue creado con correctamente");

                    return RedirectToAction("Lista", "Articulo" );

                }
                else
                {
                    CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo articulo");
                }
                return View(art);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GuardarYCrearOtro(ArticuloDTO art)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._servicioArticulo.Guardar(art);
                    CrearNotificacionExitosa("Articulo " + art.Descripcion + " fue creado con correctamente");
                    art.Descripcion = null;
                    art.Codigo = null;
                    return View("Crear", art);

                }
                else
                {
                    CrearNotificacionDeError("Complete corectamente el formulario para crear un nuevo articulo");
                    return View("Crear", art);

                }
            }
            catch
            {
                return View("Crear");
            }
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Cancelar()
        {
            try
            {
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Editar(int id)
        {
            return View(this._servicioArticulo.ObtenerArticulo(id));
        }

        [HttpPost]
        public ActionResult Editar(ArticuloDTO art)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._servicioArticulo.Editar(art);
                    CrearNotificacionExitosa("Articulo  fue editado con correctamente");
                    return RedirectToAction("Lista", "Articulo");

                }
                else
                {
                    CrearNotificacionDeError("Complete corectamente el formulario para crear un editar el articulo");
                }
                return View(art);
            }
            catch
            {
                return View();
            }
        }

        // POST: ArticuloController/Create
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

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
