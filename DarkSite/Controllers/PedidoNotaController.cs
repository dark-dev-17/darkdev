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
    public class PedidoNotaController : Controller
    {
        private DarkDev.DarkDev darkDev;
        public PedidoNotaController(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.Pedido);
            darkDev.LoadObject(GpsManagerObjects.PedidoNota);
            darkDev.LoadObject(GpsManagerObjects.Proveedor);
            darkDev.LoadObject(GpsManagerObjects.Articulo);
            darkDev.LoadObject(GpsManagerObjects.ProductoTipo);
        }

        // GET: PedidoNota
        public ActionResult Index(int id)
        {
            return View(darkDev.PedidoNota.Get("" + id, nameof(darkDev.PedidoNota.Element.IdPedido)));
        }

        // GET: PedidoNota/Details/5
        public ActionResult Details(int id)
        {
            var Productos = darkDev.Articulo.Get("" + id, nameof(darkDev.Articulo.Element.IdPedidoNota));
            ViewData["Productos"] = Productos;
            
            return View(darkDev.PedidoNota.Get(id));
        }

        // GET: PedidoNota/Create
        public ActionResult Create(int id)
        {
            return View(new PedidoNota { IdPedido = id });
        }

        // POST: PedidoNota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoNota PedidoNota)
        {
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(PedidoNota);
                }

                float totalPedido = darkDev.Pedido.Get(PedidoNota.IdPedido).Total;
                float totalNotas = darkDev.PedidoNota.Get("" + PedidoNota.IdPedido, nameof(darkDev.PedidoNota.Element.IdPedido)).Sum(a => a.Total);

                if (totalNotas + PedidoNota.Total > totalPedido)
                {
                    darkDev.RolBack();
                    ModelState.AddModelError(nameof(PedidoNota.Total), string.Format("totales de notas exceden el total del pedido, total pedido: ${0}, total notas: ${1}, restante: ${2}",
                        totalPedido,
                        totalNotas,
                        totalPedido - totalNotas));
                    return View(PedidoNota);
                }

                darkDev.PedidoNota.Element = PedidoNota;
                if (darkDev.PedidoNota.Add())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "Pedido", new { id = PedidoNota.IdPedido, Mode = "Notas" });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(PedidoNota);
                }
            }
            catch(DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(PedidoNota);
            }
        }

        // GET: PedidoNota/Edit/5
        public ActionResult Edit(int id)
        {
            var result = darkDev.PedidoNota.Get(id);
            return View(result);
        }

        // POST: PedidoNota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoNota PedidoNota)
        {
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(PedidoNota);
                }

                float totalPedido = darkDev.Pedido.Get(PedidoNota.IdPedido).Total;
                float totalNotas = darkDev.PedidoNota.Get("" + PedidoNota.IdPedido, nameof(darkDev.PedidoNota.Element.IdPedido)).Where(a=> a.IdPedidoNota != PedidoNota.IdPedidoNota).ToList().Sum(a => a.Total);

                if (totalNotas + PedidoNota.Total > totalPedido)
                {
                    darkDev.RolBack();
                    ModelState.AddModelError(nameof(PedidoNota.Total), string.Format("totales de notas exceden el total del pedido, total pedido: ${0}, total notas sin actual: ${1}, restante: ${2}",
                        totalPedido,
                        totalNotas,
                        totalPedido - totalNotas));
                    return View(PedidoNota);
                }

                darkDev.PedidoNota.Element = PedidoNota;
                if (darkDev.PedidoNota.Update())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "Pedido", new { id = PedidoNota.IdPedido, Mode = "Notas" });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(PedidoNota);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(PedidoNota);
            }
        }

        // GET: PedidoNota/Delete/5
        public ActionResult Delete(int id)
        {
            return View(darkDev.PedidoNota.Get(id));
        }

        // POST: PedidoNota/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            darkDev.StartTransaction();
            try
            {
                // TODO: Add delete logic here
                var PedidoNota = darkDev.PedidoNota.Get(id);
                if(PedidoNota != null)
                {
                    darkDev.PedidoNota.Element = PedidoNota;
                    if (darkDev.PedidoNota.Delete())
                    {
                        darkDev.Commit();
                        return RedirectToAction(nameof(Details), "Pedido", new { id = PedidoNota.IdPedido, Mode = "Notas" });
                    }
                    else
                    {
                        darkDev.RolBack();
                        return NotFound(darkDev.GetLastMessage());
                    }
                    
                }
                else
                {
                    darkDev.RolBack();
                    return NotFound("No se encontro el registro");
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