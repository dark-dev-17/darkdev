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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> List = null;
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente Cliente_ = new Cliente(dBMysql1);
                List = Cliente_.List();
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

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente Cliente_ = new Cliente(dBMysql1);
                Cliente_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Cliente_);
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

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]Cliente Cliente_)
        {
            try
            {
                if (!ModelState.IsValid){
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente_.SetConnection(dBMysql1);
                int Result = Cliente_.Create();
                dBMysql1.CloseConnection();
                if(Result == 0)
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
                return BadRequest(ex.Message);
            }
            catch (MySqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente Cliente_ = new Cliente(dBMysql1);
                Cliente_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Cliente_);
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

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody]Cliente Cliente_)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Campos vacios");
                }
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente_.SetConnection(dBMysql1);
                int Result = Cliente_.Update();
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
                return BadRequest(ex.Message);
            }
            catch (MySqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente Cliente_ = new Cliente(dBMysql1);
                Cliente_.GetById(id);
                dBMysql1.CloseConnection();
                return View(Cliente_);
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

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletee(int id)
        {
            try
            {
                // TODO: Add delete logic here
                DBMysql dBMysql1 = new DBMysql();
                dBMysql1.OpenConnection();
                Cliente Cliente_ = new Cliente(dBMysql1);
                Cliente_.Id = id;
                int Result = Cliente_.Delete();
                dBMysql1.CloseConnection();
                if (Result == 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}