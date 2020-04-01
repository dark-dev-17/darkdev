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
    public class CuentaAbonoController : Controller
    {
        // GET: CuentaAbono
        public ActionResult Index()
        {
            List<CuentaAbono> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                CuentaAbono CuentaAbono_ = new CuentaAbono(dBMysql1);
                List = CuentaAbono_.List();
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

        // GET: CuentaAbono/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                CuentaAbono CuentaAbono_ = new CuentaAbono(dBMysql1);
                bool isExists = CuentaAbono_.GetById(id);
                
                dBMysql1.CloseConnection();
                if (isExists)
                {
                    return View(CuentaAbono_);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, string.Format("No se ha encontrado el registro"));
                    return View(CuentaAbono_);
                }
                    
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
        }

        // GET: CuentaAbono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaAbono/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuentaAbono CuentaAbono_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(CuentaAbono_);
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                CuentaAbono_.SetConnection(dBMysql1);
                int Result = CuentaAbono_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, string.Format("No se ha podido registrar"));
                    return View(CuentaAbono_);
                }
            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(CuentaAbono_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(CuentaAbono_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,string.Format("System Error: {0}", ex.Message) );
                return View(CuentaAbono_);
            }
        }

        // GET: CuentaAbono/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                CuentaAbono CuentaAbono_ = new CuentaAbono(dBMysql1);
                bool isExists = CuentaAbono_.GetById(id);

                dBMysql1.CloseConnection();
                if (isExists)
                {
                    return View(CuentaAbono_);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, string.Format("No se ha encontrado el registro"));
                    return View(CuentaAbono_);
                }

            }
            catch (DBException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View();
            }
        }

        // POST: CuentaAbono/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CuentaAbono CuentaAbono_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                CuentaAbono_.SetConnection(dBMysql1);
                int Result = CuentaAbono_.Update();
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
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(CuentaAbono_);
            }
            catch (MySqlException ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(CuentaAbono_);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, string.Format("System Error: {0}", ex.Message));
                return View(CuentaAbono_);
            }
        }
    }
}