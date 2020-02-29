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
    public class PedidoAbonoController : Controller
    {
        // GET: PedidoAbono
        public ActionResult Index()
        {
            List<PedidoAbono> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAbono PedidoAbono_ = new PedidoAbono(dBMysql1);
                List = PedidoAbono_.List();
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
                PedidoAbono PedidoAbono_ = new PedidoAbono(dBMysql1);
                PedidoAbono_.GetById(id);
                dBMysql1.CloseConnection();
                return View(PedidoAbono_);
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoAbono/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoAbono PedidoAbono_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAbono_.SetConnection(dBMysql1);
                int Result = PedidoAbono_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
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

        // GET: PedidoAbono/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAbono PedidoAbono_ = new PedidoAbono(dBMysql1);
                PedidoAbono_.GetById(id);
                dBMysql1.CloseConnection();
                return View(PedidoAbono_);
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
        public ActionResult Edit(PedidoAbono PedidoAbono_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                PedidoAbono_.SetConnection(dBMysql1);
                int Result = PedidoAbono_.Update();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
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
    }
}