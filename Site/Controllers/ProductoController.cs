using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Site.Models;
using Site.Models.Sistema;

namespace Site.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<Producto> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto Producto_ = new Producto(dBMysql1);
                List = Producto_.List();
                //List = NotaPedido_.ListByPedido(id);
                dBMysql1.CloseConnection();
                return View(List);
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto Producto_ = new Producto(dBMysql1);
                Producto_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Producto_);
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto Producto_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Producto_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto_.SetConnection(dBMysql1);
                int Result = Producto_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Producto_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto Producto_ = new Producto(dBMysql1);
                Producto_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Producto_);
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto Producto_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Producto_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto_.SetConnection(dBMysql1);
                int Result = Producto_.Update();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Producto_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(Producto_);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Producto Producto_ = new Producto(dBMysql1);
                Producto_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Producto_);
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}