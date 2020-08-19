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
    public class PedidoController : Controller
    {
        private DarkDev.DarkDev darkDev;
        public PedidoController(IConfiguration configuration)
        {
            darkDev = new DarkDev.DarkDev(configuration);
            darkDev.OpenConnection();
            darkDev.LoadObject(GpsManagerObjects.Pedido);
            darkDev.LoadObject(GpsManagerObjects.PedidoNota);
            darkDev.LoadObject(GpsManagerObjects.AportacionesPedidos);
            darkDev.LoadObject(GpsManagerObjects.Proveedor);
            darkDev.LoadObject(GpsManagerObjects.Inversionista);
            darkDev.LoadObject(GpsManagerObjects.Articulo);
            darkDev.LoadObject(GpsManagerObjects.ProductoTipo);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var Pedidos = darkDev.Pedido.Get();
            Pedidos.ForEach(a => {
                a.ProvedorNombre = darkDev.Proveedor.Get(a.IdProveedor).Nombre;
            });
            return View(Pedidos.OrderBy(a => a.FechaCompra));
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id, string Mode)
        {
            var PedidoNotas = darkDev.PedidoNota.Get("" + id, nameof(darkDev.PedidoNota.Element.IdPedido));
            var Aportaciones = darkDev.AportacionesPedidos.Get("" + id, nameof(darkDev.AportacionesPedidos.Element.IdPedido));
            Aportaciones.ForEach(a => {
                a.NombreInversionista = darkDev.Inversionista.Get(a.IdInversionista).NombreCompleto;
            });

            List<Articulo> Articulos = new List<Articulo>();
            PedidoNotas.ForEach(a => {
                darkDev.Articulo.Get("" + a.IdPedidoNota, nameof(darkDev.Articulo.Element.IdPedidoNota)).ForEach( b => {
                    b.ProductoTipoNombre = darkDev.ProductoTipo.Get(b.IdProductoTipo).Nombre;
                    b.FolioNota = darkDev.PedidoNota.Get(a.IdPedidoNota).Folio;

                    Articulos.Add(b);
                });

            });

            ViewData["PedidoNotas"] = PedidoNotas;
            ViewData["AportacionesPedidos"] = Aportaciones;
            ViewData["Articulos"] = Articulos;
            ViewData["Mode"] = Mode;





            return View(darkDev.Pedido.Get(id));
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewData["Proveedores"] = new SelectList(darkDev.Proveedor.Get().OrderBy(a => a.Nombre).ToList(), "IdProveedor", "Nombre");
            return View(new Pedido { FechaCompra = DateTime.Now });
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            ViewData["Proveedores"] = new SelectList(darkDev.Proveedor.Get().OrderBy(a => a.Nombre).ToList(), "IdProveedor", "Nombre", pedido.IdProveedor);
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(pedido);
                }
                darkDev.Pedido.Element = pedido;
                if (darkDev.Pedido.Add())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(pedido);
                }
            }
            catch(DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(pedido);
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            var result = darkDev.Pedido.Get(id);
            ViewData["Proveedores"] = new SelectList(darkDev.Proveedor.Get().OrderBy(a => a.Nombre).ToList(), "IdProveedor", "Nombre", result.IdProveedor);
            return View(result);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido pedido)
        {
            ViewData["Proveedores"] = new SelectList(darkDev.Proveedor.Get().OrderBy(a => a.Nombre).ToList(), "IdProveedor", "Nombre", pedido.IdProveedor);
            darkDev.StartTransaction();
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    darkDev.RolBack();
                    return View(pedido);
                }
                darkDev.Pedido.Element = pedido;
                if (darkDev.Pedido.Update())
                {
                    darkDev.Commit();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    darkDev.RolBack();
                    ModelState.AddModelError("", darkDev.GetLastMessage());
                    return View(pedido);
                }
            }
            catch (DarkDev.Exceptions.DarkException ex)
            {
                darkDev.RolBack();
                ModelState.AddModelError("", ex.Message);
                return View(pedido);
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["PedidoNotas"] = darkDev.PedidoNota.Get("" + id, nameof(darkDev.PedidoNota.Element.IdPedido));
            return View(darkDev.Pedido.Get(id));
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            darkDev.StartTransaction();
            try
            {
                // TODO: Add delete logic here
                var pedido = darkDev.Pedido.Get(id);
                if(pedido != null)
                {
                    if (darkDev.Pedido.Delete())
                    {
                        darkDev.Commit();
                        return RedirectToAction(nameof(Index));
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