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
    public class NotaPedidoController : Controller
    {
        private NotaPedido NotaPedido__;
        // GET: NotaPedido
        public ActionResult Index(int id)
        {
            List<NotaPedido> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido NotaPedido_ = new NotaPedido(dBMysql1);
                List = NotaPedido_.List();
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

        // GET: NotaPedido/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido NotaPedido_ = new NotaPedido(dBMysql1);
                NotaPedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(NotaPedido_);
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

        // GET: NotaPedido/Create
        public ActionResult Create(int id)
        {
            NotaPedido__ = new NotaPedido();
            NotaPedido__.Id_Pedido = id;
            return View(NotaPedido__);
        }
        // POST: NotaPedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotaPedido NotaPedido_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(NotaPedido_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido_.SetConnection(dBMysql1);
                int Result = NotaPedido_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Details","Pedido",new { id = NotaPedido_.Id_Pedido });
                }
                else
                {
                    return View(NotaPedido_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
        }

        // GET: NotaPedido/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido NotaPedido_ = new NotaPedido(dBMysql1);
                NotaPedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(NotaPedido_);
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

        // POST: NotaPedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotaPedido NotaPedido_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(NotaPedido_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido_.SetConnection(dBMysql1);
                int Result = NotaPedido_.Update();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Details", "Pedido", new { id = NotaPedido_.Id_Pedido });
                }
                else
                {
                    return View(NotaPedido_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(NotaPedido_);
            }
        }

        // GET: NotaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                NotaPedido NotaPedido_ = new NotaPedido(dBMysql1);
                NotaPedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(NotaPedido_);
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

        // POST: NotaPedido/Delete/5
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