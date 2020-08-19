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
    public class AportacionesPedidosController : Controller
    {
        private DarkDev.DarkDev darkDev;
        public AportacionesPedidosController(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.AportacionesPedidos);
            darkDev.LoadObject(GpsManagerObjects.Pedido);
            darkDev.LoadObject(GpsManagerObjects.Inversionista);
        }

        // GET: AportacionesPedidos
        public ActionResult Index(int id)
        {
            return View(darkDev.AportacionesPedidos.Get("" + id, nameof(darkDev.AportacionesPedidos.Element.IdPedido)));
        }

        // GET: AportacionesPedidos/Details/5
        public ActionResult Details(int id)
        {
            var detalle = darkDev.AportacionesPedidos.Get(id);
            detalle.NombreInversionista = darkDev.Inversionista.Get(detalle.IdInversionista).NombreCompleto;
            return View(detalle);
        }

        // GET: AportacionesPedidos/Create
        public ActionResult Create(int id)
        {
            ViewData["Inversionistas"] = new SelectList(darkDev.Inversionista.Get().OrderBy(a => a.NombreCompleto), "IdInversionista", "NombreCompleto");
            return View(new AportacionesPedidos { IdPedido = id });
        }

        // POST: AportacionesPedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AportacionesPedidos AportacionesPedidos)
        {
            ViewData["Inversionistas"] = new SelectList(darkDev.Inversionista.Get().OrderBy(a => a.NombreCompleto), "IdInversionista", "NombreCompleto", AportacionesPedidos.IdInversionista);
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(AportacionesPedidos);
                }

                float totalPedido = darkDev.Pedido.Get(AportacionesPedidos.IdPedido).Total;

                float totalAportaciones = darkDev.AportacionesPedidos.Get("" + AportacionesPedidos.IdPedido, nameof(darkDev.AportacionesPedidos.Element.IdPedido)).Sum(a => a.Aporte);

                if(totalAportaciones+ AportacionesPedidos.Aporte > totalPedido)
                {
                    darkDev.RolBack();
                    ModelState.AddModelError(nameof(AportacionesPedidos.Aporte), string.Format("Aportes exceden el total del pedido, total pedido: ${0}, total aportes: ${1}, restante: ${2}", 
                        totalPedido, 
                        totalAportaciones,
                        totalPedido - totalAportaciones));
                    return View(AportacionesPedidos);
                }

                darkDev.AportacionesPedidos.Element = AportacionesPedidos;
                if (darkDev.AportacionesPedidos.Add())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "Pedido", new { id = AportacionesPedidos.IdPedido, Mode = "AportacionesPedidos" });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(AportacionesPedidos);
                }
            }
            catch(DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(AportacionesPedidos);
            }
        }

        // GET: AportacionesPedidos/Edit/5
        public ActionResult Edit(int id)
        {
            var result = darkDev.AportacionesPedidos.Get(id);
            ViewData["Inversionistas"] = new SelectList(darkDev.Inversionista.Get().OrderBy(a => a.NombreCompleto), "IdInversionista", "NombreCompleto", result.IdInversionista);
            return View(result);
        }

        // POST: AportacionesPedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AportacionesPedidos AportacionesPedidos)
        {
            ViewData["Inversionistas"] = new SelectList(darkDev.Inversionista.Get().OrderBy(a => a.NombreCompleto), "IdInversionista", "NombreCompleto", AportacionesPedidos.IdInversionista);
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(AportacionesPedidos);
                }

                float totalPedido = darkDev.Pedido.Get(AportacionesPedidos.IdPedido).Total;

                float totalAportaciones = darkDev.AportacionesPedidos.Get("" + AportacionesPedidos.IdPedido, nameof(darkDev.AportacionesPedidos.Element.IdPedido)).Where(a => a.IdAportacionesPedidos != AportacionesPedidos.IdAportacionesPedidos).ToList().Sum(a => a.Aporte);

                if (totalAportaciones + AportacionesPedidos.Aporte > totalPedido)
                {
                    darkDev.RolBack();
                    ModelState.AddModelError(nameof(AportacionesPedidos.Aporte), string.Format("Aportes exceden el total del pedido, total pedido: ${0}, total aportes sin actual: ${1}, restante: ${2}",
                        totalPedido,
                        totalAportaciones,
                        totalPedido - totalAportaciones));
                    return View(AportacionesPedidos);
                }

                darkDev.AportacionesPedidos.Element = AportacionesPedidos;
                if (darkDev.AportacionesPedidos.Update())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Details), "Pedido", new { id = AportacionesPedidos.IdPedido, Mode = "AportacionesPedidos" });
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(AportacionesPedidos);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(AportacionesPedidos);
            }
        }

        // GET: AportacionesPedidos/Delete/5
        public ActionResult Delete(int id)
        {
            var result = darkDev.AportacionesPedidos.Get(id);
            ViewData["Inversionistas"] = new SelectList(darkDev.Inversionista.Get().OrderBy(a => a.NombreCompleto), "IdInversionista", "NombreCompleto", result.IdInversionista);
            return View(result);
        }

        // POST: AportacionesPedidos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            darkDev.StartTransaction();
            try
            {
                // TODO: Add delete logic here
                var AportacionesPedidos = darkDev.AportacionesPedidos.Get(id);
                if(AportacionesPedidos != null)
                {
                    darkDev.AportacionesPedidos.Element = AportacionesPedidos;
                    if (darkDev.AportacionesPedidos.Delete())
                    {
                        darkDev.Commit();
                        return RedirectToAction(nameof(Details), "Pedido", new { id = AportacionesPedidos.IdPedido, Mode = "AportacionesPedidos" });
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