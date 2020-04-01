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
    public class PedidoAjusteController : Controller
    {
        // GET: PedidoAbono
        public ActionResult Index()
        {
            List<PedidoAjuste> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAjuste PedidoAjuste_ = new PedidoAjuste(dBMysql1);
                List = PedidoAjuste_.List();
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

        // GET: PedidoAbono/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAjuste PedidoAjuste_ = new PedidoAjuste(dBMysql1);
                PedidoAjuste_.GetById(id);
                dBMysql1.CloseConnection();
                return View(PedidoAjuste_);
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

        // GET: PedidoAbono/Create
        public ActionResult Create(int id)
        {
            PedidoAjuste PedidoAjuste_ = new PedidoAjuste();
            PedidoAjuste_.Id_pedido = id;
            return View(PedidoAjuste_);
        }

        // POST: PedidoAbono/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoAjuste PedidoAjuste_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(PedidoAjuste_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAjuste_.SetConnection(dBMysql1);
                int Result = PedidoAjuste_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Details", "Pedido", new { id = PedidoAjuste_.Id_pedido });
                }
                else
                {
                    return View(PedidoAjuste_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
        }

        // GET: PedidoAbono/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAjuste PedidoAjuste_ = new PedidoAjuste(dBMysql1);
                PedidoAjuste_.GetById(id);
                dBMysql1.CloseConnection();
                return View(PedidoAjuste_);
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

        // POST: PedidoAbono/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoAjuste PedidoAjuste_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(PedidoAjuste_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAjuste_.SetConnection(dBMysql1);
                int Result = PedidoAjuste_.Update();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Details", "Pedido", new { id = PedidoAjuste_.Id_pedido });
                }
                else
                {
                    return View(PedidoAjuste_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(PedidoAjuste_);
            }
        }
    }
}