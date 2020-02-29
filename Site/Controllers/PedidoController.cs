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
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            List<Pedido> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido Pedido_ = new Pedido(dBMysql1);
                List = Pedido_.List();
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

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido Pedido_ = new Pedido(dBMysql1);
                Pedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Pedido_);
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

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido Pedido_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido_.SetConnection(dBMysql1);
                int Result = Pedido_.Create();
                dBMysql1.CloseConnection();
                if (Result == 0)
                {
                    return Ok("Cliente agregado");
                }
                else
                {
                    throw new Exception("Error al insertar");
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

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido Pedido_ = new Pedido(dBMysql1);
                Pedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Pedido_);
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

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido Pedido_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido_.SetConnection(dBMysql1);
                int Result = Pedido_.Update();
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
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido Pedido_ = new Pedido(dBMysql1);
                Pedido_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Pedido_);
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

        // POST: Pedido/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Pedido Pedido_ = new Pedido(dBMysql1);
                Pedido_.Id = id;
                int Result = Pedido_.Delete();
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
            catch
            {
                return View();
            }
        }
    }
}