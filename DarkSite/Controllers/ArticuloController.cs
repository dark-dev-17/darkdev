using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkDev;
using DarkDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace DarkSite.Controllers
{
    public class ArticuloController : Controller
    {
        private DarkDev.DarkDev darkDev;
        public ArticuloController(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.Articulo);
            darkDev.LoadObject(GpsManagerObjects.ProductoTipo);
            darkDev.LoadObject(GpsManagerObjects.PedidoNota);
        }

        // GET: ArticuloController
        public ActionResult Index(int id)
        {
            var result = darkDev.Articulo.Get(""+id, nameof(darkDev.Articulo.Element.IdPedidoNota));
            result.ForEach(a => {
                a.ProductoTipoNombre = darkDev.ProductoTipo.Get(a.IdProductoTipo).Nombre;
                a.FolioNota = darkDev.PedidoNota.Get(a.IdPedidoNota).Folio;
            });
            return View(result);
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            var result = darkDev.Articulo.Get(id);
            return View(result);
        }

        // GET: ArticuloController/Create
        public ActionResult Create(int id)
        {
            var ProductoTipos = darkDev.ProductoTipo.Get();
            ViewData["ProductoTipos"] = new SelectList(ProductoTipos, nameof(darkDev.ProductoTipo.Element.IdProductoTipo), nameof(darkDev.ProductoTipo.Element.Nombre));
            return View(new Articulo { IdPedidoNota = id, Codigo = "aa-aa-aa" });
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo articulo)
        {
            ViewData["ProductoTipos"] = new SelectList(darkDev.ProductoTipo.Get(), nameof(darkDev.ProductoTipo.Element.IdProductoTipo), nameof(darkDev.ProductoTipo.Element.Nombre), articulo.IdProductoTipo);
            darkDev.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(articulo);
                }

                darkDev.Articulo.Element = articulo;
                darkDev.Articulo.Element.FechaCompra = DateTime.Now;
                if (darkDev.Articulo.Add())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "PedidoNota", new { id = articulo.IdPedidoNota });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(articulo);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(articulo);
            }
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            var articulo = darkDev.Articulo.Get(id);
            
            ViewData["ProductoTipos"] = new SelectList(darkDev.ProductoTipo.Get(), nameof(darkDev.ProductoTipo.Element.IdProductoTipo), nameof(darkDev.ProductoTipo.Element.Nombre),articulo.IdProductoTipo);
            return View(articulo);
        }

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Articulo articulo)
        {
            ViewData["ProductoTipos"] = new SelectList(darkDev.ProductoTipo.Get(), nameof(darkDev.ProductoTipo.Element.IdProductoTipo), nameof(darkDev.ProductoTipo.Element.Nombre), articulo.IdProductoTipo);
            darkDev.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(articulo);
                }

                darkDev.Articulo.Element = articulo;

                if (darkDev.Articulo.Update())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "PedidoNota", new { id = articulo.IdPedidoNota });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(articulo);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(articulo);
            }
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            var articulo = darkDev.Articulo.Get(id);
            return View(articulo);
        }

        // POST: ArticuloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            darkDev.StartTransaction();
            try
            {
                var articulo = darkDev.Articulo.Get(id);
                darkDev.Articulo.Element = articulo;

                if (darkDev.Articulo.Delete())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "PedidoNota", new { id = articulo.IdPedidoNota });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(articulo);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                return NotFound(ex.Message);
            }
        }
    }
}
