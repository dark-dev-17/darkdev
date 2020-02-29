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
    public class InversionistaController : Controller
    {
        // GET: Inversionista
        public ActionResult Index()
        {
            List<Inversionista> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Inversionista Inversionista_ = new Inversionista(dBMysql1);
                List = Inversionista_.List();
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

        // GET: Inversionista/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Inversionista Inversionista_ = new Inversionista(dBMysql1);
                Inversionista_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Inversionista_);
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

        // GET: Inversionista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inversionista/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inversionista Inversionista_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Inversionista_.SetConnection(dBMysql1);
                int Result = Inversionista_.Create();
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

        // GET: Inversionista/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Inversionista Inversionista_ = new Inversionista(dBMysql1);
                Inversionista_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Inversionista_);
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

        // POST: Inversionista/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inversionista Inversionista_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Inversionista_.SetConnection(dBMysql1);
                int Result = Inversionista_.Update();
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